       // write the initial buffer
       char[] buffer = "Initial text".ToCharArray();
       Console.WriteLine(buffer);
       // ensure the cursor starts off on the line of the text by moving it up one line
       Console.SetCursorPosition(Console.CursorLeft + buffer.Length, Console.CursorTop - 1);
       // process the key presses in a loop until the user presses enter
       // (this might need to be a bit more sophisticated - what about escape?)
       ConsoleKeyInfo keyInfo = Console.ReadKey(true);
       while (keyInfo.Key != ConsoleKey.Enter)
       {
           switch (keyInfo.Key)
           {
                case ConsoleKey.LeftArrow:
                        ...
                  // process the left key by moving the cursor position
                  // need to keep track of the position in the buffer
             // if the user presses another key then update the text in our buffer
             // and draw the character on the screen
             // there are lots of cases that would need to be processed (backspace, delete etc)
           }
           keyInfo = Console.ReadKey(true);
       }
