    dynamic test="Senthil";
    Console.Writeline(test.GetType())  // System.String
    
    test=1222;
    Console.Writeline(test.GetType())  // System.Int32
    
    test=new List<string>();
    Console.Writeline(test.GetType())  //System.Collections.Generic.List'1[System.String]
