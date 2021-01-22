    static string IPAddrToBinary(string input)
    {
        return String.Join(".", ( // join segments
            input.Split('.').Select( // split segments into a string[]
                // take each element of array, name it "x",
                //   and return binary format string
                x => Convert.ToString(Int32.Parse(x), 2).PadLeft(8, '0')
            // convert the IEnumerable<string> to string[],
            // which is 2nd parameter of String.Join
            )).ToArray());
    }
