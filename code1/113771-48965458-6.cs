        public class Spinner : IDisposable
        {
            private const string Sequence1 = @"/-\|";
            private const string Sequence3 = @".o0o";
            private const string Sequence2 = @"<^>v";
            private const string Sequence4 = @"#■.";
            private const string Sequence5 = @"▄▀";
            private const string Sequence = @"└┘┐┌";
            private string BusyMessage = "";
            private int counter = 0;
            private readonly int delay;
            private bool active;
            private readonly Thread thread;
    
            public Spinner(int delay = 200)
            {
                this.delay = delay;
                thread = new Thread(Spin);
            }
    
            public void Start()
            {
                active = true;
                Console.CursorVisible = false;
                if (!thread.IsAlive)
                {
                    thread.Start();
                }
            }
    
            public void Start(string busyMessage)
            {
                BusyMessage = busyMessage;
                Start();
            }
    
            public void Stop()
            {          
                active = false;
                Console.CursorVisible = true;
                ClearCurrentConsoleLine();
                BusyMessage = "";
            }
    private static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    
            private void Spin()
            {
                while (active)
                {
                    Turn();
                    Thread.Sleep(delay);
                }
            }
    
            /// <summary>
            /// Draws the busy indicator
            /// </summary>
            /// <param name="c">if empty char, then clear screen</param>
        private void Draw(char c)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.Write('[');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(c);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(']');
            if (!string.IsNullOrEmpty(BusyMessage))
            {
                Console.Write(" " + BusyMessage);
            }
            
            //reset cursor position
            Console.SetCursorPosition(left, top);
        }
    
            private void Turn()
            {
                Draw(Sequence[++counter % Sequence.Length]);
            }
    
            public void Dispose()
            {
                Stop();
            }
        }
