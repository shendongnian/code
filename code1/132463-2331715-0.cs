                List<string> temp = arr1.ToList<string>();
                foreach (string s in arr1)
                {
                    if (!arr2.Contains(s))
                    {
                        temp.Add(s);
                    }
                }
                String[] arr3 = temp.ToArray<string>();  
