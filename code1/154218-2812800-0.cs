            static void Main(string[] args)
        {
            var list = new List<string>(){
                "a","b","c"
            };
            Thread t1 = new Thread(new ParameterizedThreadStart(DoWork));
            t1.Start(list);
            Console.ReadLine();
            
        }
        public static void DoWork(object stuff)
        {
            foreach (var item in stuff as List<string>)
            {
                Console.WriteLine(item);
            }
        }
