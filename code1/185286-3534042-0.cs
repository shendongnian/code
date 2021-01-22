        string username = "LastName, FirstName";
        string[] words = username.Split(new string[]{", "});
        string result = words[1] + "." + words[0]; // storing
         // for output
        Console.WriteLine("{0}.{1}", words[1], words[0]);
        Console.WriteLine(result);
