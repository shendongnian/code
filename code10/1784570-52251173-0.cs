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
    Console.WriteLine(stringBuilder.ToString());
