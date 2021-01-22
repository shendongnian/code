        /// <summary>
        /// Writes a string at the x position, y position = 1;
        /// Tries to catch all exceptions, will not throw any exceptions.  
        /// </summary>
        /// <param name="s">String to print usually "*" or "@"</param>
        /// <param name="x">The x postion,  This is modulo divided by the window.width, 
        /// which allows large numbers, ie feel free to call with large loop counters</param>
        protected static void WriteProgress(string s, int x) {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            // Console.WindowWidth = 10;  // this works. 
            int width = Console.WindowWidth;
            x = x % width;
            try {
                Console.SetCursorPosition(x, 1);
                Console.Write(s);
            } catch (ArgumentOutOfRangeException e) {
            } finally {
                try {
                    Console.SetCursorPosition(origRow, origCol);
                } catch (ArgumentOutOfRangeException e) {
                }
            }
        }
