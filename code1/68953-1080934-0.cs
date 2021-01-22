    // fn takes a method which returns string, calls it, and prints it.
    void PrintsAMethodsResult(Func<string> GetString)
    {
      Console.WriteLine( GetString() );
    }
    // calls like this;
    PrintsAMethodResult( Car.GetNumberPlate );
