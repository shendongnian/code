                Dictionary<int, int> dictionaryTest = new Dictionary<int, int>();
                for (int i = 0; i < testArray.Length; i++)
                {
                    dictionaryTest.Add(i, testArray[i]);
                }
                foreach (KeyValuePair<int, int> item in dictionaryTest)
                {
                    
                    
                    Console.WriteLine("Array Position {0} and Position Value {1}",item.Key,item.Value); 
                }
