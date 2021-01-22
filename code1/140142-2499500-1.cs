        static Dictionary<int, Dictionary<int, int>> 
                               CountEachNumber(int[,] list, int height, int width)
        {
            // Containging
            //      Number
            //      Information
            //          Line
            //          Occurences
            var dict = new Dictionary<int, Dictionary<int,int>>();
            for (int i = 0; i < height; i++)
            {
                for (int a = 0; a < width; a++)
                {
                    var number = list[i, a];
                    if (dict.ContainsKey(number))
                    {
                        if (dict[number].ContainsKey(a))
                        {
                            dict[number][a]++;
                        }
                        else
                        {
                            dict[number].Add(a, 1);
                        }
                    }
                    else
                    {
                        var val = new Dictionary<int, int>();
                        val.Add(a, 1);
                        dict.Add(number, val);
                    }
                }
            }
            return dict;
        }
