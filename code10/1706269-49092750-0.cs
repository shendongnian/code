            static double Root(int number, int multiplier, int level)
            {
                double results = 0;
                if (level > 0)
                {
                    results = Root(number, multiplier, level - 1); 
                }
                if (level % 2 == 0)
                {
                    results += multiplier * Math.Sqrt(number);
                }
                else
                {
                    results += multiplier * Math.Sqrt(number);
                }
                return results;
            }
