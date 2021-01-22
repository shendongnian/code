    for (int p = input.Length;  p > 0;  p--)
    {
        char  ch;
        do
        {
            ch = input[--p];
        } while ((ch < '0'  ||  ch > '9')  &&  ch != ' '  &&  p > 0);
        p++;
        int  num;
        if (int.TryParse(input.Substring(0, p), out num))
            return num;
    }
    throw new Exception("Malformed integer: " + input);
