    string[] lines = new[] { "line1", "line2" };
    StringReader input = new StringReader(String.Join(Environment.NewLine, lines));
    Console.SetIn(input);
    
    string input1 = Console.ReadLine();    //will return 'line1'
    string input2 = Console.ReadLine();    //will return 'line2'
