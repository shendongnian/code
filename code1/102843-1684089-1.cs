    public static List<T> RemoveDuplicateSections<T>(List<T> sections) where T:INamedObject
            {
                Dictionary<string, int> uniqueStore = new Dictionary<string, int>();
                List<T> finalList = new List<T>();
                int i = 0;
                foreach (T currValue in sections)
                {
                    if (!uniqueStore.ContainsKey(currValue.Name))
                    {
                        uniqueStore.Add(currValue.Name, 0);
                        finalList.Add(sections[i]);
                    }
                    i++;
                 }
                return finalList;
            }
