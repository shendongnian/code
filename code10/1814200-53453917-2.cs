    List<ExpandoObject> FinalList = new List<ExpandoObject>();
            foreach (Person p in inputlist)
            {
                ExpandoObject tempExpando = new ExpandoObject();
                IDictionary<string, object> TempDictionary = tempExpando as IDictionary<string, object>;
                foreach (var kvp in ColumnHeaderDictionary)
                {
                    TempDictionary.Add(kvp);
                }
                TempDictionary[nameof(Person.Name)] = p.Name;
                foreach(Treat t in p.Treats)
                {
                    TempDictionary[t.Name] = t.Value;
                }
                
                FinalList.Add(tempExpando);
            }
            return FinalList;
