    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string");
        string str = Console.ReadLine();
        string replacedStr = null;
        // This loop will repalce all repeat black space in single space
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (!(Convert.ToString(str[i]) == " " &&
                Convert.ToString(str[i + 1]) == " "))
            {
                replacedStr = replacedStr + str[i];
            }
        }
        replacedStr = replacedStr + str[str.Length-1]; // Append last character
        replacedStr = replacedStr.Replace(" ", "%20");
        Console.WriteLine(replacedStr);
        Console.ReadLine();
    }
