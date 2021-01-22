    // Regular casting
    Class1 x = new Class1();
    Class2 y = (Class2)x; // Throws exception if x doesn't implement or derive from Class2
    
    // Casting with as
    Class2 y = x as Class2; // Sets y to null if it can't be casted.  Does not work with int to short, for example.
    
    if (y != null)
    {
      // We can use y
    }
    
    // Casting but checking before.
    // Only works when boxing/unboxing or casting to base classes/interfaces
    if (x is Class2)
    {
      y = (Class2)x; // Won't fail since we already checked it
      // Use y
    }
    
    // Casting with try/catch
    // Works with int to short, for example.  Same as "as"
    try
    {
      y = (Class2)x;
      // Use y
    }
    catch (InvalidCastException ex)
    {
      // Failed cast
    }
