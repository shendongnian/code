    public static unsafe int Calc2(string sInput)
    {
       var buf = "";
       var start = sInput.IndexOf(' ');
       var value1 = int.Parse(sInput.Substring(0, start));
       string op = null;
       var iResult = 0;
       var isOp = false;
       fixed (char* p = sInput)
       {
          for (var i = start + 1; i < sInput.Length; i++)
          {
             var cur = *(p + i);
             if (cur == ' ')
             {
                if (!isOp)
                {
                   op = buf;
                   isOp = true;
                }
                else
                {
                   var value2 = int.Parse(buf);
                   switch (op[0])
                   {
                      case '+': iResult += value1 + value2; break;
                      case '-': iResult += value1 - value2; break;
                      case '*': iResult += value1 * value2; break;
                      case '/': iResult += value1 / value2; break;
                   }
    
                   value1 = value2;
                   isOp = false;
                }
    
                buf = "";
             }
             else
             {
                buf += cur;
             }
          }
       }
    
       return iResult;
    }
    private static void Main(string[] args)
    {
       var input = "14 + 2 * 32 / 60 + 43 - 7 + 3 - 1 + 0 * 7 + 87 - 32 / 34";
       var sb = new StringBuilder();
       sb.Append(input);
       for (var i = 0; i < 10000000; i++)
          sb.Append(" + " + input);
       var sw = new Stopwatch();
       sw.Start();
       Calc2(sb.ToString());
       sw.Stop();
       Console.WriteLine($"sw : {sw.Elapsed:c}");
    }
    
