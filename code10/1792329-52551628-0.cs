    string input = "NGGOEUIUVNVUENEPRAYX";
    int index = 0, iteration = 1;
    while (input.Length > 0)
    {
        if (index >= input.Length)
        {
            index = 0;
            iteration++;
        }
        Console.Write(input[index]);
        input = input.Remove(index, 1);
        index += 4 - iteration;
    }
