    Dictionary<int, Dictionary<string, double>> data = new Dictionary<int, Dictionary<string, double>>()
            {
                {
                    0,new Dictionary<string, double>(){{ "eat" , 0.15 },{ "food" , 0.16} }
                },
                {
                    1,new Dictionary<string, double>(){{ "eat" , 0.32 },{ "food" , 0.2 } }
                }
            };
            Dictionary<string, double> finalResultDic = new Dictionary<string, double>();
            foreach (var entry in data)
            {
                foreach (var subEntry in entry.Value)
                {
                    if (finalResultDic.ContainsKey(subEntry.Key))
                    {
                        finalResultDic[subEntry.Key] *= subEntry.Value;
                    }
                    else
                    {
                        finalResultDic.Add(subEntry.Key, subEntry.Value);
                    }
                }
            }
            var finalResult = finalResultDic.Sum(dic => dic.Value);
