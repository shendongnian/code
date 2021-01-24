    private static int GetInput()
    {
       try
       {
          var result = ValidateRadius(Console.ReadLine());
          if(!result.IsSuccessful)
             Console.WriteLine(result.FailureReason);
          else
             Console.WriteLine("Okay");
    
          return result.Radius;
       catch // Here you can handle specific exception types, or bubble to a higher level. Log exception details and either terminate or present users with a generic "Whoops" and let them retry the operation.
       {
           Console.WriteLine("An unexpected error occurred.")
       }
    }
