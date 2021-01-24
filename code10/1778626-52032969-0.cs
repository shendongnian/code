    List<string> input = new List<string> { "A", "B", "C", "C", "C", "A", "B", "C", "C" };
    
                Dictionary<string, int> output = new Dictionary<string, int>();
                foreach(var item in input)
                {
                    if (output.ContainsKey(item))
                    {
                        output[item] = output[item] + 1;
                    }
                    else
                    {
                        output.Add(item, 1);
                    }
                }
