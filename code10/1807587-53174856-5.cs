    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.AllPropertiesSet += delegate { AllPropsSet(); };
            t.Id = 1;
            t.Name = "asd";
            Console.ReadKey();
        }
        static void AllPropsSet()
        {
            Console.WriteLine("All properties have been set.");
        }
    }
