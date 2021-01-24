    public static void arrayfrequency(int[] a)
    {
        var result = new Dictionary<int,int>();
        foreach (int item in a)
        {
            if (!result.ContainsKey(item))
            {
                result.Add(item, 1);
            }
            else
            { 
                result[item]++;
            }
        }
        foreach(var key in result.Keys)
        {
            Console.WriteLine("{0} {1}", key, result[key]);
        }
    }
