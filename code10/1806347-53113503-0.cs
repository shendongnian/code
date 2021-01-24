    private static object _lock = new object();
    private static int mIdx = 0;
    public static string GenerateNumber()
    {
         lock (_lock)
         {
              return $"ABC{mIdx++}";
         }
    }
