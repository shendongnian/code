    class Program
    {
        static void Main()
        {
            Dictionary<Type, IParameter> parameters = 
              new Dictionary<Type, IParameter>();
            parameters.Add(typeof(FP12), new FP12 { fieldFP12 = "This is FP12" });
            parameters.Add(typeof(FP11), new FP11 { fieldFP11 = "This is FP11"});
    
            // THIS IS WHERE YOU GET THE IPARAMETER YOU WANT - THE GENERICS WAY...
            var fp12 = parameters.GetParameter<FP12>();
            var fp11 = parameters.GetParameter<FP11>();
    
            Console.WriteLine(fp12.fieldFP12);
            Console.WriteLine(fp11.fieldFP11);
            Console.ReadLine();
        }
    }
