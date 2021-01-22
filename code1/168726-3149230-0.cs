    // Method that returns anonymous type as object
    object ReturnAnonymous()
    {
      return new { City="Prague", Name="Tomas" };
    }
    
    // Application entry-point
    void Main()
    {
      // Get instance of anonymous type with 'City' and 'Name' properties
      object o = ReturnAnonymous();
      
      // This call to 'Cast' method converts first parameter (object) to the
      // same type as the type of second parameter - which is in this case 
      // anonymous type with 'City' and 'Name' properties
      var typed = Cast(o, new { City="", Name="" });
      Console.WriteLine("Name={0}, City={1}", typed.Name, typed.City);
    }
    
    // Cast method - thanks to type inference when calling methods it 
    // is possible to cast object to type without knowing the type name
    T Cast<T>(object obj, T type)
    {
      return (T)obj;
    }
