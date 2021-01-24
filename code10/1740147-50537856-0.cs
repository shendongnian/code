    public static void linearSearch(double[] _arr, double max, double min, double avg)
        {
            int mxindx = 0;
            int mnindx = 0;
            int avgindx = 0;
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] == max)
                {
                    mxindx = i;
                }
                if (_arr[i] == min)
                {
                    mnindx = i;
                }
                if (_arr[i] == Math.Round(avg, 2))
                {
                    avgindx = i;
                }
            }
            Console.WriteLine("Maximum index number: {0}, Minimum index number: {1}, Average index number: {2}", mxindx, mnindx, avgindx);
            Console.WriteLine();
        }
    }
