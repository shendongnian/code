    using System;
    class Program
    {
        static void Main()
        {
            (new Program()).Confusion();
            Console.ReadKey();
        }
        public Action this[Action index]
        {
            get {
                return () => Console.WriteLine("Executing");
            }
        }
        Func<Program> GetInstance()
        {
            return () => this;
        }
        void Confusion()
        {
            // This is particularly ugly...
            GetInstance()()[()=>{}]();
        }
    }
