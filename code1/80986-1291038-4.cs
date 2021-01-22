    class Program {
        static void Main(string[] args) {
            Processor<int> p = new Processor<int>((data) => { Console.WriteLine(data);  });
            p.Queue(1);
            p.Queue(2); 
            Console.Read();
            p.Queue(3);
        }
    }
