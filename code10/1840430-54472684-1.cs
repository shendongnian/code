    static  void Main(string[] args)
    {
       var input = new decimal[] { 1, 2, 2, 4, 5, 6, 6, 6, 9, 10, 11, 12, 13, 14, 15 };
       var result = input.MovingAvg(2);
       Console.WriteLine(string.Join(", ",result));
    }
