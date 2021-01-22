            //A SortedDictionary is sorted on the key (not value)
            System.Collections.Generic.SortedDictionary<string, string> testSortDic = new SortedDictionary<string, string>();
            //Add some values with the keys out of order
            testSortDic.Add("key5", "value 1");
            testSortDic.Add("key3", "value 2");
            testSortDic.Add("key2", "value 3");
            testSortDic.Add("key4", "value 4");
            testSortDic.Add("key1", "value 5");            
            //Display the elements.  
            foreach (KeyValuePair<string, string> kvp in testSortDic)
            {
                Console.WriteLine("Key = {0}, value = {1}", kvp.Key, kvp.Value);
            }
            /*  OUTPUT RESULT:
                Key = key1, value = value 5
                Key = key2, value = value 3
                Key = key3, value = value 2
                Key = key4, value = value 4
                Key = key5, value = value 1             
             */
