    internal static class ListMergeExtension
    {
        public static void Reconcile<T, TKey>(this IList<T> left, IList<T> right, Func<T, TKey> keySelector) where T : class
        {
            Dictionary<TKey, T> leftDict = left.ToDictionary(keySelector);
            int index = 0;
            // Go through each item in the new list in order to find all updated and new elements
            foreach (T newObj in right)
            {
                TKey key = keySelector(newObj);
                T oldObj = null;
                // First, find an object in the new list that shares its key with an object in the old list
                if (leftDict.TryGetValue(key, out oldObj))
                {
                    // An object in each list was found with the same key, so now check to see if any properties have changed and
                    // if any have, then assign the object from the new list over the top of the equivalent element in the old list
                    ReconcileObject(left, oldObj, newObj);
                    // Remove the item from the dictionary so that all that remains after the end of the current loop are objects
                    // that were not found (sharing a key with any object) in the new list - so these can be removed in the next loop
                    leftDict.Remove(key);
                }
                else
                {
                    // The object in the new list is brand new (has a new key), so insert it in the old list at the same position
                    left.Insert(index, newObj);
                }
                index++;
            }
            // Go through all remaining objects in the dictionary and remove them from the master list as the references to them were
            // not removed earlier, thus indicating they no longer exist in the new list (by key)
            foreach (T removed in leftDict.Values)
            {
                left.Remove(removed);
            }
        }
        public static void ReconcileOrdered<T>(this IList<T> left, IList<T> right) where T : class
        {
            // Truncate the old list to be the same size as the new list if the new list is smaller
            for (int i = left.Count; i > right.Count; i--)
            {
                left.RemoveAt(i - 1);
            }
            // Go through each item in the new list in order to find all updated and new elements
            foreach (T newObj in right)
            {
                // Assume that items in the new list with an index beyond the count of the old list are brand new items
                if (left.Count > right.IndexOf(newObj))
                {
                    T oldObj = left[right.IndexOf(newObj)];
                    // Check the corresponding objects (same index) in each list to see if any properties have changed and if any
                    // have, then assign the object from the new list over the top of the equivalent element in the old list
                    ReconcileObject(left, oldObj, newObj);
                }
                else
                {
                    // The object in the new list is brand new (has a higher index than the previous highest), so add it to the old list
                    left.Add(newObj);
                }
            }
        }
        private static void ReconcileObject<T>(IList<T> left, T oldObj, T newObj) where T : class
        {
            if (oldObj.GetType() == newObj.GetType())
            {
                foreach (PropertyInfo pi in oldObj.GetType().GetProperties())
                {
                    // Don't compare properties that have this attribute and it is set to false
                    var mergable = (MergablePropertyAttribute)pi.GetCustomAttributes(false).FirstOrDefault(attribute => attribute is MergablePropertyAttribute);
                    if ((mergable == null || mergable.AllowMerge) && !object.Equals(pi.GetValue(oldObj, null), pi.GetValue(newObj, null)))
                    {
                        if (left is ObservableCollection<T>)
                        {
                            pi.SetValue(oldObj, pi.GetValue(newObj, null), null);
                        }
                        else
                        {
                            left[left.IndexOf(oldObj)] = newObj;
                            // The entire record has been replaced, so no need to continue comparing properties
                            break;
                        }
                    }
                }
            }
            else
            {
                // If the objects are different subclasses of the same base type, assign the new object over the old object
                left[left.IndexOf(oldObj)] = newObj;
            }
        }
    }
