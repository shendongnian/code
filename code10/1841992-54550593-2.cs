    List<string> source = new List<string>();
    source.Add("AA BB CC DD EE FF GG HH");
    source.Add("BB DD EE AA HH II JJ MM");
    source.Add("NN OO AA RR EE BB FF KK");
    string ToCompare = "BB GG AA FF CC MM RR II";
    string word1, word2, word3, existingKey;
    string[] compareList = ToCompare.Split(new string[] { " " }, StringSplitOptions.None);
    Dictionary<string, int> ResultDictionary = new Dictionary<string, int>();
    for (int i = 0; i < compareList.Length - 2; i++)
    {
        word1 = compareList[i];
        for (int j = i + 1; j < compareList.Length - 1; j++)
        {
            word2 = compareList[j];
            for (int z = j + 1; z < compareList.Length; z++)
            {
                word3 = compareList[z];
                source.ForEach(x =>
                {
                    if (x.Contains(word1) && x.Contains(word2) && x.Contains(word3))
                    {
                        existingKey = ResultDictionary.Keys.FirstOrDefault(y => y.Contains(word1) && y.Contains(word2) && y.Contains(word3));
                        if (string.IsNullOrEmpty(existingKey))
                        {
                            ResultDictionary.Add(word1 + " " + word2 + " " + word3, 1);
                        }
                        else
                        {
                            ResultDictionary[existingKey]++;
                        }
                    }
                });
            }
        }
    }
