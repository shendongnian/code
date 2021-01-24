    var input = 54721704;
    var str = input.ToString();
    var result = new List<string>();
    for (int i = 0; i < str.Length; i++)
    {
        if (i == 0)
        {
            result.Add(str[i].ToString());
            continue;
        }
        if (Char.GetNumericValue(str[i]) % 2 == Char.GetNumericValue(str[i - 1]) % 2)
        {
            result[result.Count() - 1] += str[i].ToString();
        }
        else
        {
            result.Add(str[i].ToString());
        }
    }
    Console.WriteLine(string.Join(", ", result));
