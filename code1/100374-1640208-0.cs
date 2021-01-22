    public static class BindingListExtension
    {
        public static void Reconcile<T, TKey>(this BindingList<T> left,
                                              BindingList<T> right,
                                              Func<T, TKey> keySelector) where T : class
        {
            Dictionary<TKey, T> leftDict = left.ToDictionary(key => keySelector(key));
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
                    foreach (PropertyInfo pi in typeof(T).GetProperties())
                    {
                        if (!pi.GetValue(oldObj, null).Equals(pi.GetValue(newObj, null)))
                        {
                            left[left.IndexOf(oldObj)] = newObj;
                            break;
                        }
                    }
                    // Remove the item from the dictionary so that all that remains after the end of the current loop are objects
                    // that were not found (sharing a key with any object) in the new list - so these can be removed in the next loop
                    leftDict.Remove(key);
                }
                else
                {
                    // The object in the new list is brand new (has a new key), so add it to the old list
                    left.Add(newObj);
                }
            }
            // Go through all remaining objects in the dictionary and remove them from the master list as the references to them were
            // not removed earlier, thus indicating they no longer exist in the new list (by key)
            foreach (T removed in leftDict.Values)
            {
                left.Remove(removed);
            }
        }
    }
