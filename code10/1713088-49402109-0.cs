    int myInt
    if(int.TryParse("10", out myInt))
    {
        //Do Something
    }
    else 
    {
        int myInt2
        if(int.TryParse("100", out myInt2))
        {
            // Do Something else
        }
    }
    
    System.Console.WriteLine(myInt);
    System.Console.WriteLine(myInt2); //<-- Compile Error 'myInt2 doesn't exists
