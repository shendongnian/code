      static int outCol, outRow, outHeight = 10;
      static void Main(string[] args)
      {
         bool quit = false;
         System.DateTime dt = DateTime.Now;
         do
         {
            if (Console.KeyAvailable)
            {
               if (Console.ReadKey(false).Key == ConsoleKey.Escape)
                  quit = true;
            }
            System.Threading.Thread.Sleep(0);
            if (DateTime.Now.Subtract(dt).TotalSeconds > .1)
            {
               dt = DateTime.Now;
               WriteOut(dt.ToString(" ss.ff"), false);
            }            
         } while (!quit);
      }
      static void WriteOut(string msg, bool appendNewLine)
      {
         int inCol, inRow;
         inCol = Console.CursorLeft;
         inRow = Console.CursorTop;
         int outLines = getMsgRowCount(outCol, msg) + (appendNewLine?1:0);
         int outBottom = outRow + outLines;
         if (outBottom > outHeight)
            outBottom = outHeight;
         if (inRow <= outBottom)
         {
            int scrollCount = outBottom - inRow + 1;
            Console.MoveBufferArea(0, inRow, Console.BufferWidth, 1, 0, inRow + scrollCount);
            inRow += scrollCount;
         }
         if (outRow + outLines > outHeight)
         {
            int scrollCount = outRow + outLines - outHeight;
            Console.MoveBufferArea(0, scrollCount, Console.BufferWidth, outHeight - scrollCount, 0, 0);
            outRow -= scrollCount;
            Console.SetCursorPosition(outCol, outRow);
         }
         Console.SetCursorPosition(outCol, outRow);
         if (appendNewLine)
            Console.WriteLine(msg);
         else
            Console.Write(msg);
         outCol = Console.CursorLeft;
         outRow = Console.CursorTop;
         Console.SetCursorPosition(inCol, inRow);
      }
      static int getMsgRowCount(int startCol, string msg)
      {
         string[] lines = msg.Split('\n');
         int result = 0;
         foreach (string line in lines)
         {
            result += (startCol + line.Length) / Console.BufferWidth;
            startCol = 0;
         }
         return result + lines.Length - 1;
      }
