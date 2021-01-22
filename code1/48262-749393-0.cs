        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Recurse(0);
                }
                catch (Exception ex)
                {
                    StackTrace st = new StackTrace(ex);
                    // Go wild.
                    Console.WriteLine(st.FrameCount);
                }
                Console.ReadLine();
            }
            static void Recurse(int counter)
            {
                if (counter >= 100)
                    throw new Exception();
                Recurse(++counter);
            }
        }
