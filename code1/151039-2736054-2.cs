        public List<MyType> GetMyTypes(List<int> ids)
        {
            int index = 0;
            Dictionary<int, int> positions = ids.ToDictionary(c => index++);
            MyType[] results = new MyType[ids.Count];
            foreach (MyType aType in (from myType in db.MyTypes
                                        where ids.Contains(myType.Id)
                                        orderby myType.Id
                                        select myType))
            {
                results[positions[aType.Id]] = aType;
            }
            return results.ToList();
        }
