    /// <summary>
        /// Does NOT work correctly. It returns also items that are not contained in all the lists.
        /// The method FindAllCommonItemsInAllTheLists, returns a dictionary whose keys form a list of all the common items in the lists contained in the listOfLists,
        /// regardless the order of the items in the various lists.
        /// It works by creating a set of all items common to all lists processed so far and comparing each list with this set, creating a temporary set of the items 
        /// common to the current list and the list of common items so far. Effectively an O(n.m) where n is the number of lists and m the number of items in the lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfLists"></param>
        /// <returns></returns>
        public static HashSet<T> FindAllCommonItemsInAllTheLists<T>(List<List<T>> listOfLists)
        {
            HashSet<T> currentCommon = new HashSet<T>();
            HashSet<T> common = new HashSet<T>();
            foreach (List<T> currentList in listOfLists)
            {
                if (currentCommon.Count == 0)
                {
                    foreach (T item in currentList)
                    {
                        common.Add(item);
                    }
                }
                else
                {
                    foreach (T item in currentList)
                    {
                        if (currentCommon.Contains(item))
                        {
                            common.Add(item);
                        }
                    }
                }
                if (common.Count == 0)
                {
                    currentCommon.Clear();
                    break;
                }
                currentCommon.Clear(); // Empty currentCommon for a new iteration.
                foreach (T itemAnd in common) /* Copy all the items contained in common to currentCommon. 
                                               *            currentCommon = common; 
                                               * does not work because thus currentCommon and common would point at the same object and 
                                               * the next statement: 
                                               *            common.Clear();
                                               * will also clear currentCommon.
                                               */
                {
                    if (!currentCommon.Contains(itemAnd))
                    {
                        currentCommon.Add(itemAnd);
                    }
                }
                common.Clear();
            }
            return currentCommon;
        }
