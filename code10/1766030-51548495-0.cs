    public static void Main()
    {
       ConfigData cd = new ConfigData();
       EntityValidator ev = new EntityValidator();
       ValidationResult result = ev.Validate(cd);
       Console.WriteLine(result.IsValid);
       foreach (var error in result.Errors)
           Console.WriteLine(error.ErrorMessage);
       Console.ReadLine();
    }
