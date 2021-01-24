    public class AnswerCmd : IDisposable
    {
        public static void tst()
        {
            using (AnswerCmd var = new AnswerCmd())
            {
                var.add(5);
            }
        }
        public void add(int value)
        {
            Console.WriteLine($"Add: {value}");
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
