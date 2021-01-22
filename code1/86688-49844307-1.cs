                Dictionary<int, string> dictionaryTest = new Dictionary<int, string>();
                for (int i = 0; i < testArray.Length; i++)
                {
                    dictionaryTest.Add(i, testArray[i]);
                }
                foreach (KeyValuePair<int, string> item in dictionaryTest)
                {
                    
                    
                    Console.WriteLine("Array Position {0} and Position Value {1}",item.Key,item.Value.ToString()); 
                }
