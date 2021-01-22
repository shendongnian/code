    class Program
    {
        static void Main(string[] args)
        {
            Double i = Double.NaN;
		    while (!i.Equals(i)) //this would be result in false
		    //while(i != i) // this would result in true.
		    {
			    Console.WriteLine("Hello");
		    }
        }
    }
