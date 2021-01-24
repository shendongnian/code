    var output = new StringBuilder();
    bool escape = false;
    for (var i = 0; i < input.Length; ++i)
    {
        if (escape)
        {
            output.Append(input[i]);
            escape = false;
        }
        else
        {
            switch (input[i])
            {
                case '\\':
                    escape = true;
                    break;
                case '&':
                    output.Append('§');
                    break;
                default:
                    output.Append(input[i]);
                    break;
            }
        }
    }
