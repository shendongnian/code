        char END = '#';
       var sb = new StringBuilder();
        Console.WriteLine("Write a line ending in '#'.");
    
        while (true) 
        {
            var ch = Convert.ToChar(Console.Read());
            if (ch == END) 
                break;
            sb.Append(ch)
        }
    }
    Console.WriteLine("You have typed " + sb.ToString());
