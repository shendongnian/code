            public static List<List<int>> Balance(List<int> input)
        {
            var result = new List<List<int>>();
            if (input.Count > 0)
            {
                var values = new List<int>(input);
                values.Sort();
                var max = values.Max();
                var maxIndex = values.FindIndex(v => v == max);
                for (int i = maxIndex; i < values.Count; i++)
                {
                    result.Add(new List<int> { max });
                }
                var limit = maxIndex;
                for (int i = 0; i < limit / 2; i++)
                {
                    result.Add(new List<int> { values[i], values[(limit - 1) - i] });
                }
                if (limit % 2 != 0)
                {
                    result.Add(new List<int> { values[limit / 2] });
                }
            }
            return result;
        }
