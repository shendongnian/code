    internal class Program
    {
        private static void Main()
        {
            const string SomeString = "hello";
            Console.WriteLine("Original string:'{0}'.", SomeString);
            unsafe
            {
                fixed (char* charArray = SomeString)
                {
                    byte* buffer = (byte*)(charArray);
                    buffer[0] = 66;
                    buffer[2] = 76;
                    buffer[4] = 73;
                    buffer[6] = 78;
                    buffer[8] = 71;
                }
            }
            Console.WriteLine("Mutated string:'{0}'.", SomeString);
        }
    }
