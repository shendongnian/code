        public void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Name 1");
            list.Add("Name 2");
            list.Add("Name 3");
            list.Add("Name 4");
            Func<string, bool> logicFunc = (listItemValue) => listItemValue == "Name 1";
            ReplaceReference(list, "Name 5", logicFunc);
        }
        public static void ReplaceReference<T>(ICollection<T> collection, T newReference, Func<T, bool> predicate)
        {
            var typeName = typeof(T).Name;
            var newCollection = collection.ToList();
            for (int i = 0; i < newCollection.Count; i++)
            {
                if (predicate(newCollection[i]))
                {
                    newCollection[i] = newReference;
                }
            }
        }
