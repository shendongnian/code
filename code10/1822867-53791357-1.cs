    string vWord2 = "6566679798899";
    if (vWord2.Length % 2 > 0) 
    {
        Console.WriteLine($"Not a vaid input");
    }
    else 
    {
        var result2 = new StringBuilder();
        for (int i = 0; i < vWord2.Length; i += 2) 
        {
            if (int.TryParse(vWord2.Substring(i, 2), out int n)) 
            {
                result2.Append((char)n);
            }
            else {
                Console.WriteLine($"{vWord2.Substring(i, 2)} is not a vaid input");
            }
        }
    }
