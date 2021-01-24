    StringBuilder stringBuilder = new StringBuilder();
    StringBuilder lineBuilder = new StringBuilder();
        
    int counter = 0;
    int size = 4;
    while (counter < size) // size is 4
    {
       counter++;
       lineBuilder.Append("$");
       stringBuilder.Append($"{lineBuilder}\n");               
    }
    
    string[] lines = stringBuilder.ToString().Split('\n');
    while (counter > 0)
    {                
       stringBuilder.Append(lines[counter-1]);
       stringBuilder.Append("\n");
       counter--;
    }
    Console.WriteLine(stringBuilder.ToString());
