    static void Main(string[] args)
    {
        bool isParamaterMandatory = true;
        Address address = new Address()
        {
            City = "Paris",
            Name = "Adam",
            Parameter1 = GetParameterIfNeeded(isParamaterMandatory)
        };
    
        Console.ReadKey();
    
    }
    
    private static string GetParameterIfNeeded(bool isNeeded)
    {
        if (isNeeded)
        {
            return "Mandatory";
        }
    
        return null;
    }
