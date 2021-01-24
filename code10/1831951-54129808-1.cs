    private static string CutOff(string input, int length)
    {
        if (length >= input.Length) return input; //whole input
        var index = length - 1;
        if (char.IsWhiteSpace(input[index])) return input.Substring(0, length); //just cut off
        if (length < input.Length - 1 && !char.IsWhiteSpace(input[length]))
        {
            //word continues, search for whitespace character to the left
            while (length >= 0 && !char.IsWhiteSpace(input[length]))
            {
                length--;
            }
            if ( length == 0)
            {
                //single long word
                return "Can't cut off without breaking word";
            }
        }
        //cut off by length
        return input.Substring(0, length);
    }
