    foreach (DictionaryEntry entry in sourceList)
                {
                    Debug.WriteLine(entry.Key);
                    foreach (object item in (ArrayList)entry.Value)
                    {
                        Debug.WriteLine(item.ToString());
                    }
     
                }
