    var result = new StringBuilder();
    var ASCIIValues = vWord.Split();
    foreach (string CharValue in ASCIIValues) {
        if (int.TryParse(CharValue, out int n) && n < 127) {
            result.Append((char)n);
        }
        else {
            Console.WriteLine($"{CharValue} is not a vaid input");
            break;
        }
    }
    Console.WriteLine($"Result string: {result.ToString()}");
