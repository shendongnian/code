    static void Main(string[] args)
    {
        double max = 0d;
        double sum = 0d;
        int index = 0;
        string[] txt = File.ReadLines(@"c: \Users\Stark\Moisture_Data.txt").ToArray();
        double[] arr = txt.Select(Double.Parse).ToArray();
        print(arr);
        Console.WriteLine();
        max = maximum(arr, sum, max);
        Console.WriteLine();
        Index(arr, max, index);
        Console.ReadLine();
    }
    public static double maximum(double[] arr, double sum, double max)
    {
        for (int i = 0; i < arr.Length; i++) {
            sum += arr.Length;
            if (max < arr[i]) {
                max = arr[i];
            }
        }
        Console.Write("\nMaximim value in array: {0}", max);
        return max;
    }
    public static void Index(double[] arr, double max, int index)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (max == arr[i])
            {
                index = i;
            }
        }
