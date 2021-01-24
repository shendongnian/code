           foreach(TKey key in randK)
            {
                if (!tempDict.ContainsKey(key))
                {
                    tempDict.Add(key, dictionary[key]);
                    Console.WriteLine("key = " + key.ToString());
                }
                //------------------------------------------
                // the easy fix it here
                if(tempDict.Count() == keepN) break;
                //-----------------------------------
            }
