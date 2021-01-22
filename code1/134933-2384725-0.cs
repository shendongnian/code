    SortedDictionary<string, int> dic = new SortedDictionary<string, int>();
    
                for (int i = 0; i < 10; i++)
                {
                    if (dic.ContainsKey("Word" + i))
                        dic["Word" + i]++;
                    else
                        dic.Add("Word" + i, 0);
                }
    
                //to get the array of words:
                List<string> wordsList = new List<string>(dic.Keys);
                string[] wordsArr = wordsList.ToArray();
    
                //to get the array of values
                List<int> valuesList = new List<int>(dic.Values);
                int[] valuesArr = valuesList.ToArray();
