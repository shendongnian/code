        /// <summary>
        /// get count of every recursive objects
        /// </summary>
        /// <param name="list">your list</param>
        /// <param name="childrenPropertyName">your chil property</param>
        /// <returns></returns>
        public int GetCountOfEveryRecursiveObjects(IList list, string childrenPropertyName)
        {
            int count = list.Count;
            foreach (object item in list)
            {
                System.Reflection.PropertyInfo property = item.GetType().GetProperty(childrenPropertyName);
                IList childList = (IList)property.GetValue(item);
                if (childList == null)
                    continue;
                count += GetCountOfEveryRecursiveObjects(childList, childrenPropertyName);
            }
            return count;
        }
