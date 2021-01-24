       static void Main(string[] args)
            {
                // setting up test data, can be removed from actual solution where objects can be populated as required
                List<MyObject> objects = new List<MyObject>();
                objects = GetData(); 
                int i = 0;
                int key = 0;
                List<WrapMyObject> wObjs = new List<WrapMyObject>();
                Dictionary<int, string> origDictionary = new Dictionary<int, string>();
                Dictionary<int, string> searchDictionary = new Dictionary<int, string>();
                
    
                // adding the directory path to the renamed filename as well, since same filename can be there for different filepath
                Func<string, string> GetFilePath = (path) => path.Substring(0, path.LastIndexOf('\\'));
                objects.ForEach(x=>x.Renamedname = GetFilePath(x.Originalname) + "\\" + x.Renamedname);
    
                //sort the whole list by timestamp, this should ensure that we begin always with the orignal file and always get subsequent changed filename in the list
                //the algorithm relies on the fact that the renamed name should be the next orignal name for that file change in the sorted list 
                //if current item's orignal name is not in search dictory then we are seeing this file path first time, add to orignal dictionary with key, add the renamed name in search dictionary with same key
                //else add add the search path found in searchDictionary back into origDictionary and update the searchDict with the new path value (current item renamed path)
                var sortedObjects = objects.OrderBy(o => o.Timestamp);
                foreach (var item in objects)
                {              
                    if (searchDictionary.ContainsValue(item.Originalname))
                        {                    
                            key = searchDictionary.Where(x => x.Value == item.Originalname).First().Key;
                            origDictionary[key] = origDictionary[key] + "!" + searchDictionary[key];
                            searchDictionary[key] = item.Renamedname;
                        }
                        else
                        {
                            origDictionary.Add(i, item.Originalname);
                            searchDictionary.Add(i, item.Renamedname);
                        }
                    i++;
                }            
                //iterated the whole list of objects....which means the final node would be remaining in the search dictionary, add them back to origDictionary to complete the modified path
                searchDictionary.ToList().ForEach(x => origDictionary[x.Key] = origDictionary[x.Key] + "!" + searchDictionary[x.Key]);
    
                //at this point orgnalDict has the list of all names that each file was modified with.
            }
