     public static int ReadInt(string prompt)
     {
         Console.Clear();
         var length = prompt.Length + 2;     //2 is for a colon and a space
         var position = length;
         Console.Write($"{prompt}: ");
         string buffer = String.Empty;
         int returnNum = 0;
         while (true)
         {
             Console.SetCursorPosition(position, 0);
             var charRead = Console.ReadKey();
             if(charRead.KeyChar == '\r')
             {
                 return returnNum;
             }
             if (!int.TryParse(buffer + charRead.KeyChar, out returnNum))
             {
                 Console.SetCursorPosition(position, 0);
                 Console.WriteLine(" "); //overwrite
                 Console.SetCursorPosition(0, 1);
                 Console.Write("Error: enter only digits");
                 continue;
             }
             else
             {
                 buffer += charRead.KeyChar;
                 ++position;
                 //overwrite any error
                 Console.SetCursorPosition(0, 1);
                 Console.Write("                         ");
             }
         }
     }
