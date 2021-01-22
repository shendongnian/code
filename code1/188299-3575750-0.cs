            public static List<List<int>> Balance(List<int> input, int desiredLimit)
        {
            var result = new List<List<int>>();
            if (input.Count > 0)
            {
                var values = new List<int>(input);
                values.Sort();
                var start = 0;
                var end = values.Count - 1;
                var orderedValues = new List<int>(values.Count);
                while (start < end)
                {
                    orderedValues.Add(values[start]);
                    orderedValues.Add(values[end]);
                    start++;
                    end--;
                }
                if (values.Count % 2 != 0)
                {
                    orderedValues.Add(values[values.Count / 2]);
                }
                var total = 0;
                var line = new List<int>();
                for (int i = 0; i < orderedValues.Count; i++)
                {
                    var v = orderedValues[i];
                    total += v;
                    if (total <= desiredLimit)
                    {
                        line.Add(v);
                    }
                    else
                    {
                        total = v;
                        result.Add(line);
                        line = new List<int>() { v };
                    }
                }
                result.Add(line);
            }
            return result;
        }
