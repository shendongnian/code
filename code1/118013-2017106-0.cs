        #region IDataBindable Members
        public List<NameValueType> ToList()
        {
            List<NameValueType> resultList = new List<NameValueType>();
            using (DataContext context = new DataContext())
            {
                List<Monster> itemList = context.Monsters.ToList();
                foreach (Monster item in itemList)
                {
                    resultList.Add(new NameValueType(item.MonsterId.ToString(), item.Name));
                }
            }
            return resultList;
        }
        #endregion
