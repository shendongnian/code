        public enum MyVars
        {
            MyOne = 12345, MyTwo = 54321, MyThree = 33333 
        }
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("Name:{0}, Val={1}", MyVars.MyOne.ToString(), (int)MyVars.MyOne ));
            Console.ReadKey();
        }
