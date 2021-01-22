    var i = 0;
    var output = new List<byte>();
    while (i < input.Length)
    {
        if (input[i] == '=' && input[i+1] == '\r' && input[i+2] == '\n')
        {
            // skip this
            i += 3;
        }
        else if (input[i] == '=')
        {
            byte b = (construct the byte from the characters input[i+1] and input[i+2]);
            output.Add(b);
            i += 3;
        }
        else
        {
            output.Add((byte)input[i]);
            i++;
        }
    }
