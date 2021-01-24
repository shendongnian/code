    List<string> source = new List<string>();
    source.Add("2 4 6 8 10 12 14 99");
    source.Add("16 18 20 22 24 26 28 102");
    source.Add("33 6 97 38 50 34 87 88");
    string ToCompare = "2 4 6 15 20 22 28 44";
    string word1, word2, word3, existingKey;
    string[] compareList = ToCompare.Split(new string[] { " " }, StringSplitOptions.None);
    string[] sourceList, keywordList;
    Dictionary<string, int> ResultDictionary = new Dictionary<string, int>();
    source.ForEach(x =>
    {
        sourceList = x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < compareList.Length - 2; i++)
        {
            word1 = compareList[i];
            for (int j = i + 1; j < compareList.Length - 1; j++)
            {
                word2 = compareList[j];
                for (int z = j + 1; z < compareList.Length; z++)
                {
                    word3 = compareList[z];
                    if (sourceList.Contains(word1) && sourceList.Contains(word2) && sourceList.Contains(word3))
                    {
                        existingKey = ResultDictionary.Keys.FirstOrDefault(y =>
                                      {
                                          keywordList = y.Split(new string[] { " " }, StringSplitOptions.None);
                                          return keywordList.Contains(word1) && keywordList.Contains(word2) && keywordList.Contains(word3);
                                      });
                        if (string.IsNullOrEmpty(existingKey))
                        {
                            ResultDictionary.Add(word1 + " " + word2 + " " + word3, 1);
                        }
                        else
                        {
                            ResultDictionary[existingKey]++;
                        }
                    }
                }
            }
        }
    });
