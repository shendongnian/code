    /// <summary>
        /// The method FindCommonItems, returns a dictionary whose keys form a list of all the common items in the lists contained in the listOfLists,
        /// regardless the order of the items in the various lists.
        /// It works by creating a set of all items common to all lists processed so far and comparing each list with this set, creating a temporary set of the items 
        /// common to the current list and the list of common items so far. Effectively an O(n.m) where n is the number of lists and m the number of items in the lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfLists"></param>
        /// <returns></returns>
        public static SortedDictionary<T, bool>.KeyCollection FindAllCommonItems<T>(List<List<T>> listOfLists)
        {
            SortedDictionary<T, bool> currentCommon = new SortedDictionary<T, bool>();
            SortedDictionary<T, bool> common = new SortedDictionary<T, bool>();
            foreach (List<T> currentList in listOfLists)
            {
                if (currentCommon.Count == 0)
                {
                    foreach (T item in currentList)
                    {
                        common[item] = true;
                    }
                }
                else
                {
                    foreach (T item in currentList)
                    {
                        if (currentCommon.ContainsKey(item))
                        {
                            common[item] = true;
                        }
                    }
                }
                if (common.Count == 0)
                {
                    currentCommon.Clear();
                    break;
                }
                currentCommon.Clear(); // Empty currentCommon for a new iteration.
                foreach (KeyValuePair<T, bool> itemAnd in common) // Copy all the items contained in common to currentCommon.
                {
                    if (!currentCommon.ContainsKey(itemAnd.Key))
                    {
                        currentCommon.Add(itemAnd.Key, itemAnd.Value);
                    }
                }
                common.Clear();
            }
            return currentCommon.Keys;
        }
