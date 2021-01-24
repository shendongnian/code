    public static int Greatest(string uinput)
    {
        List<int> numbers = new List<int>();
        foreach(string str in uinput.Split(' '))
        {
            numbers.Add(int.Parse(str));
        }
        return numbers.Max();
    }
