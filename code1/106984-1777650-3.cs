    using TestConsoleApp.AdditionService;
    namespace TestConsoleApp
        class Program
        {
            static void Main(string[] args)
            {
                AdditionServiceClient client = new AdditionServiceClient();
                Complex c1 = new Complex(), c2 = new Complex();
                c1.real = 3; c1.imag = 5;
                c2.real = 1; c2.imag = 7;
                Complex result = client.Add(c1, c2);
            }
        }
    }
