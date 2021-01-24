    unsafe public static void Main(string[] args)
    {
       double[,] doubles =  {
             { 1, 2, 3, 4 },
             { 5, 6, 7, 8 },
             { 9, 9.5f, 10, 11 },
             { 12, 13, 14.3f, 15 }
          };
    
       var length = doubles.GetLength(0) + doubles.GetLength(1) * sizeof(double);
    
       fixed (double* p = doubles)
       {
          var span = new Span<double>(p, length);
          var slice = span.Slice(6, 5);
    
          foreach (var item in slice)
             Console.WriteLine(item);
       }
    }
