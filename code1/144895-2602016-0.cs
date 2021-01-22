    int myInt;
    
    if(Int32.TryParse(myInput, out myInt))
    {
      rest of code.
    }
    else
    {
      Console.WriteLine("You didn't provide a number");
    }
