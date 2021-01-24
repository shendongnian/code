      public static string GetString(string prompt)
      {
          const int pollTime = 250;       //milliseconds
          const int starTime = 8;         //pollTime quantums (in this case 2 * 250 = 2000 ms)
          string buffer = string.Empty;
          Console.Write($"{prompt}: ");
          var top = Console.CursorTop;
          var left = Console.CursorLeft;
          //two loops, 
          //outer loop is per character
          //the inner one causes a star to be output every 2 seconds, 
          //it causes the keyboard to be polled every 1/4 second
          while (true)        //this loop breaks with a return statement
          {
              var noChar = true;
              var starLoopCount = 0;
              while (noChar && starLoopCount < starTime)
              {
                  if (Console.KeyAvailable)
                  {
                      var keyRead = Console.ReadKey();
                      if (keyRead.Key == ConsoleKey.Enter)
                      {
                          OutputLine(left, top, buffer);
                          return buffer;
                      }
                      if (keyRead.Key == ConsoleKey.Backspace)
                      {
                          if (buffer.Length > 0)
                          {
                              buffer = buffer.Substring(0, buffer.Length - 1);
                              OutputLine(left, top, buffer);
                              noChar = false;
                              continue;
                          }
                      }
                      //otherwise, add the key to the buffer
                      buffer += keyRead.KeyChar;
                      OutputLine(left, top, buffer);
                      noChar = false;
                      starLoopCount = 0;
                  }
                  ++starLoopCount;
                  Thread.Sleep(pollTime);
              }
              if (noChar)
              {
                  Console.Write("*");
              }
          }
      }
      private static void OutputLine(int left, int top, string line)
      {
          Console.SetCursorPosition(left, top);
          var blank = new string(' ', 80 - left - line.Length);
          Console.Write(line + blank);
          Console.SetCursorPosition(left + line.Length, top);
      }
