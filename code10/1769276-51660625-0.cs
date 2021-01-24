        string input = "HelloWorld:123" + Environment.NewLine + "IAmABerliner:JFK";
        string[] input_split = input.Split(Environment.NewLine.ToCharArray()[0]);
        string output = "";
        for(int i = 0; i < input_split.Length; i++)
        {
            string[] split_again = input_split[i].Split(':');
            output += split_again[0] + Environment.NewLine;
        }
