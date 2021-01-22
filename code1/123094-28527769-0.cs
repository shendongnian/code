    class Program
     {
        int a;
        int b;
        int c; 
        public void Accept()
        {
        Console.WriteLine("enter the no.:");
        a=Convert.ToInt32(Console.ReadLine());
        }
        public void Process()
        {
            for (int c=1; c<=10; c++)
	        {
	    	    b = a * c;
		        Console.WriteLine("table: {0}", b);
	        }
            Console.ReadLine();
        }
        public void Display()
        {
            //Console.WriteLine(a "X" + c +"="b);
        }
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Accept();
            pr.Process();
            Console.ReadKey();
        }
    }
}
