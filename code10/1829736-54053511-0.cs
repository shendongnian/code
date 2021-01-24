    var output = sb.ToString();
    for (int i = 0; i < output.Length; i++)
    {
        if (indexes.Contains(i))
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write(output[i]);
    }
    Console.WriteLine();
