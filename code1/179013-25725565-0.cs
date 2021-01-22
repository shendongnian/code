    private static void Main()
    {
        var str = @"
                    13
                    13
                    0 6
                    0 5
                    0 1
                    0 2
                    5 3
                    6 4
                    5 4
                    3 4
                    7 8
                    9 10
                    11 12
                    9 11
                    9 12";
    
        
        using (StandardInput input = new StandardInput(new StringReader(str)))
        {
            List<int> integers = new List<int>();
            int n;
            while ((n = input.ReadInt32()) != -1)
            {
                integers.Add(n);
            }
        }
    }
