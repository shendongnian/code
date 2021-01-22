    /// <summary>.
        /// The method FindAllCommonItemsInAllTheLists, returns a HashSet that contains all the common items in the lists contained in the listOfLists,
        /// regardless of the order of the items in the various lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfLists"></param>
        /// <returns></returns>
        public static HashSet<T> FindAllCommonItemsInAllTheLists<T>(List<List<T>> listOfLists)
        {
            if (listOfLists == null || listOfLists.Count == 0)
            {
                return null;
            }
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
                foreach (T item in common) /* Copy all the items contained in common to currentCommon. 
                                            *            currentCommon = common; 
                                            * does not work because thus currentCommon and common would point at the same object and 
                                            * the next statement: 
                                            *            common.Clear();
                                            * will also clear currentCommon.
                                            */
                {
                    if (!currentCommon.Contains(item))
                    {
                        currentCommon.Add(item);
                    }
                }
                common.Clear();
            }
            return currentCommon;
        }
