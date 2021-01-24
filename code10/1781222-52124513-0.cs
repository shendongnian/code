    namespace ConsoleApp1
    {
        class Program {
            private static void unwindDU(Letter l)
            {
                dynamic dl = l;
                switch (l.Tag)
                {
                    case Letter.Tags.A: Console.WriteLine(((Letter.A)dl).value); break;
                    case Letter.Tags.B: Console.WriteLine(((Letter.B)dl).value); break;
                    case Letter.Tags.C: Console.WriteLine("C"); break;
                    case Letter.Tags.D: Console.WriteLine("D"); break;
                }
            }
    
            static void Main(string[] args)
            {
                unwindDU(Letter.NewA(1));
                unwindDU(Letter.C);
            }
        }
    }
