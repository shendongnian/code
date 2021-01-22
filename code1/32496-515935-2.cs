    public class Example {
        public Action DoStuff;
        public Action<int> DoStuffWithParameter;
        public Func<int> DoStuffWithReturnValue;
    }
    class Program {
        static void Main(string[] args) {
            var x = new Example() {
                DoStuff = () => {
                    Console.WriteLine("Did Stuff");
                },
                DoStuffWithParameter = (p) => {
                    Console.WriteLine("Did Stuff with parameter " + p);
                },
                DoStuffWithReturnValue = () => { return 99; }
            };
            x.DoStuff();
            x.DoStuffWithParameter(10);
            int value = x.DoStuffWithReturnValue();
            Console.WriteLine("Return value " + value);
            Console.ReadLine();
        }
    }
