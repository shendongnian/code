    private static volatile int _max = int.MinValue;
    
    private static readonly object _sync = new object();
    
    public static async Task<int> DoWorkLoads(string[] files)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
    
       var block = new ActionBlock<string>((Action<string>)MyMethodAsync, options);
    
       foreach (var file in files)
       {
          block.Post(file);
       }
    
       block.Complete();
       await block.Completion;
       return _max;
    }
    
    unsafe public static void MyMethodAsync(string fileName)
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
       _max = 0;
       var files = Directory.GetFiles(@"D:\ints");
       var result = DoWorkLoads(files)
          .Result;
       return result;
    }
