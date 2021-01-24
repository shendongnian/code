    //my enum
    public enum Pointer
        {
            Begin,
            First,
            Last,
            Skipped,
            Final
        }
    //method
    public static int sumFirstLast(int[,] arr, Pointer p = Pointer.Begin, int d1Length = 0, int d2Length = 0, int N = 0)
        {
            var tot = 0;
            switch (p)
            {
                case Pointer.Final:
                    return 0;
                case Pointer.Begin:
                    return sumFirstLast(arr, Pointer.First, arr.GetLength(0), arr.GetLength(1));
                case Pointer.First:
                    if (d2Length == N)
                    {
                        if (arr.GetLength(0) == 2)
                            return sumFirstLast(arr, Pointer.Last, d1Length, d2Length, 0);
                        return sumFirstLast(arr, Pointer.Skipped, d1Length, d2Length, 0);
                    }
                    tot = arr[0, N++];
                    return sumFirstLast(arr, Pointer.First, d1Length, d2Length, N) + tot;
                case Pointer.Skipped:
                    return sumFirstLast(arr, Pointer.Last, d1Length, d2Length, 0);
                case Pointer.Last:
                    if (d2Length == N)
                    {
                        return sumFirstLast(arr, Pointer.Final, d1Length, d2Length, 0);
                    }
                    tot += arr[d1Length-1, N++];
                    return sumFirstLast(arr, Pointer.Last, d1Length, d2Length, N) + tot;
                default:
                    return 0;
            }
    //and..call it
    static void Main(string[] args)
        {
            int[,] twoD = new int[,] {{ 1, 3, 5 }, {0, 0, 0},
                                 {  2, 4, 6  }}; //new array added
            Console.WriteLine(sumFirstLast(twoD));
            Console.ReadLine();
        }
