    string val = @" Jurassic World=11734562.56
                    Black Panther@4352749.21
                    The Revenant}7452893.21
                    Trainwreck{1547892.45";
    string[] lines = val.Split('\r');
    string[] movieNameArr = new string[lines.Length];
    decimal[] amountsArr = new decimal[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] split = lines[i].Split(new Char[] { '=', '@', '}', '{' });
        // replace new line or space chars with empty string 
        split[0] = Regex.Replace(split[0], @" |\n", string.Empty);
        movieNameArr[i] = split[0];
        amountsArr[i] = decimal.Parse(split[1]);
    }
    Console.WriteLine("Movie arr: [{0}]", string.Join(", ", movieNameArr));
    Console.WriteLine("Amounts arr: [{0}]", string.Join(", ", amountsArr));
    Console.ReadKey();
