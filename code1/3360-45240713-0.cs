    /// <summary>
        /// The method FindCommonItems, returns a list of all the COMMON ITEMS in the lists contained in the listOfLists.
        /// The method expects lists containing NO DUPLICATE ITEMS.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allSets"></param>
        /// <returns></returns>
        public static List<T> FindCommonItems<T>(IEnumerable<List<T>> allSets)
        {
            Dictionary<T, int> map = new Dictionary<T, int>();
            int listCount = 0; // Number of lists.
            foreach (IEnumerable<T> currentSet in allSets)
            {
                int itemsCount = currentSet.ToList().Count;
                HashSet<T> uniqueItems = new HashSet<T>();
                bool duplicateItemEncountered = false;
                listCount++;
                foreach (T item in currentSet)
                {
                    if (!uniqueItems.Add(item))
                    {
                        duplicateItemEncountered = true;
                    }                        
                    if (map.ContainsKey(item))
                    {
                        map[item]++;
                    } 
                    else
                    {
                        map.Add(item, 1);
                    }
                }
                if (duplicateItemEncountered)
                {
                    uniqueItems.Clear();
                    List<T> duplicateItems = new List<T>();
                    StringBuilder currentSetItems = new StringBuilder();
                    List<T> currentSetAsList = new List<T>(currentSet);
                    for (int i = 0; i < itemsCount; i++)
                    {
                        T currentItem = currentSetAsList[i];
                        if (!uniqueItems.Add(currentItem))
                        {
                            duplicateItems.Add(currentItem);
                        }
                        currentSetItems.Append(currentItem);
                        if (i < itemsCount - 1)
                        {
                            currentSetItems.Append(", ");
                        }
                    }
                    StringBuilder duplicateItemsNamesEnumeration = new StringBuilder();
                    int j = 0;
                    foreach (T item in duplicateItems)
                    {
                        duplicateItemsNamesEnumeration.Append(item.ToString());
                        if (j < uniqueItems.Count - 1)
                        {
                            duplicateItemsNamesEnumeration.Append(", ");
                        }
                    }
                    throw new Exception("The list " + currentSetItems.ToString() + " contains the following duplicate items: " + duplicateItemsNamesEnumeration.ToString());
                }
            }
            List<T> result= new List<T>();
            foreach (KeyValuePair<T, int> itemAndItsCount in map)
            {
                if (itemAndItsCount.Value == listCount) // Items whose occurrence count is equal to the number of lists are common to all the lists.
                {
                    result.Add(itemAndItsCount.Key);
                }
            }
            return result;
        }
