    private static void CompareStringConstants()
    {
        string str1 = "";
        string str2 = string.Empty;
        string str3 = String.Empty;
        Console.WriteLine(object.ReferenceEquals(str1, str2)); //prints True
        Console.WriteLine(object.ReferenceEquals(str2, str3)); //prints True
    }
