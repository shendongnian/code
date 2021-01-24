    private static object _sync = new object();
    
    private static int _max;
    
    public static unsafe void MyMethodAsync(string fileName)
    {
       var largest = int.MinValue;
       var content = File.ReadAllText(fileName);
    
       fixed (char* pContent = content)
       {
          var len = pContent + content.Length;
          var current = 0;
    
          for (var p = pContent; p < len; p++)
          {
             if (*p >= 48)
             {
                current = current * 10 + *p - 48;
             }
             else
             {
                if (current > largest)
                {
                   largest = current;
                }
                current = 0;
                p++;
             }
          }
    
          current = 0;
          if (current > largest)
          {
             largest = current;
          }
       }
    
       lock (_sync)
       {
          if (largest > _max)
          {
             _max = largest;
          }
       }
    }
    
    protected override int InternalRun()
    {
       var files = Directory.GetFiles(@"D:\ints");
    
       Parallel.ForEach(files, MyMethodAsync);
    
       return _max;
    }
