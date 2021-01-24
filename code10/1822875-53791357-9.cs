    string vWord2 = "11065666797989911210110177";
    int step = 2;
    var result2 = new StringBuilder();
    for (int i = 0; i < vWord2.Length; i += step)
    {
        if (int.TryParse(vWord2.Substring(i, step), out int n) && n < 127)
        {
            if (n <= 12 & i == 0) {
                i = -3; step = 3; ;
            }
            else if(n <= 12 & i >= 2) {
                step = 3; i -= step;
            }
            else {
                result2.Append((char)n);
                if (step == 3) ++i;
                step = 2;
            }
        }
        else {
            Console.WriteLine($"{vWord2.Substring(i, step)} is not a vaid input");
        }
    }
    Console.WriteLine($"Result string: {result2.ToString()}");
