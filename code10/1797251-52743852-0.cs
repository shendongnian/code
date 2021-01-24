    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 1 || keyState == -32767)
                    {
                        Console.WriteLine(i);
                        if (i == 88 ) // X Key
                        {
                            Console.WriteLine(i);
                            //Write what's gonning to happen when 'Y' pressed
                            break;
                        }
                        else if (i == 89) // Y Key
                        {
                            Console.WriteLine(i);
                            //Write what's gonning to happen when 'Y' pressed
                            break;
                        }
                        else if (i == 27) // Escape Key
                        {
                            Console.WriteLine(i);
                            //Write what's gonning to happen when 'Y' pressed
                            break;
                        }
                    }
                }
            }
        }
    }
