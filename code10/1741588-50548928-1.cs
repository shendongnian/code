    protected override unsafe int InternalRun()
    {
       var largest = int.MinValue;
    
       var files = Directory.GetFiles(@"D:\ints");
       foreach (var file in files)
       {
          var content = File.ReadAllText(file);
    
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
       }
    
       return largest;
    }
