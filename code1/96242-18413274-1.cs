    for (int p = input.Length;  p > 0;  p--)
    {
        int  num;
        if (int.TryParse(input.Substring(0, p), out num))
            return num;
    }
    throw new Exception("Malformed integer: " + input);
