    string ToString(int num)
    {
        // ToChar will return char collection in reverse order,
        // so you will need to reverse collection before using.
        // Well in your situation you will be probably needed to
        // to write Reverse method by yourself, so this is just for
        // working example
        var chArray = ToChar(num).Reverse().ToArray();
        string str = new string(chArray);
        return str;
    }
