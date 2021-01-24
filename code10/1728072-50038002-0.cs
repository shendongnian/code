    string input = @"Server:  volvo.toyota.opel.tata
    Address:  5.6.7.8
    
    Name:    DynamicLengtdfdfhString.toyota.opel.tata
    Address:  1.2.3.4";
    
    string targetLineStart = "Name:";
    string[] allLines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    
    string targetLine = String.Empty;
    foreach (string line in allLines)
        if (line.StartsWith(targetLineStart))
        {
            targetLine = line;
        }
    
    System.Console.WriteLine(targetLine);
    
    string dynamicLengthString = targetLine.Remove(0, targetLineStart.Length).Split('.')[0].Trim();
                
    
    System.Console.WriteLine("<<" + dynamicLengthString + ">>");
    System.Console.ReadKey();
