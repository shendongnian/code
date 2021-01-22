    Console.WriteLine("Enter String");
    string str = Console.ReadLine();
    string result = "";
    result += str[0]; // first character of string
            
    for (int i = 1; i < str.Length; i++)
    {
        if (str[i - 1] != str[i])
            result += str[i];
    }
    Console.WriteLine(result);
