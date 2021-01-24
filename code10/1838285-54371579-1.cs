       static void Main(string[] args)
        {
            var sortedDict = new SortedDictionary<double, double>()
            { {
                1.10 , 20 },{
                1.09 , 75 },{
                1.08 , 32 },{
                1.07 , 440},{
                1.06 , 200},{
                1.05 , 160},{
                1.04 , 130},{
                1.03 , 250},{
                1.02 , 62 },{
                1.01 , 73 },{
                1.00 , 15 }
            };
            var totalLen = sortedDict.Count;
            for(var i = 0; i < sortedDict.Count; i++)
            {
                var val = sortedDict.ElementAt(i);
                if (i - 3 >= 0 && i + 3 < totalLen)
                {
                    if (
                        sortedDict.ElementAt(i - 3).Value < val.Value &&
                        sortedDict.ElementAt(i - 2).Value < val.Value &&
                        sortedDict.ElementAt(i - 1).Value < val.Value &&
                        sortedDict.ElementAt(i + 1).Value < val.Value &&
                        sortedDict.ElementAt(i + 2).Value < val.Value &&
                        sortedDict.ElementAt(i + 3).Value < val.Value
                     )
                    {
                        Console.WriteLine(val.Key);
                    }
                }
            }
        }
