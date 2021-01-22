    int check()
    {
        string a = "asdf xyz 123 xx 3212";
        string[] seperator = { "z 1" };
        string[] arr = a.Split(seperator, StringSplitOptions.None);
        if (arr.Length > 1)
        {
            if (arr[0].Length > arr[1].Length)
                return 0;
            else
                return 1;
                    
        }
        return -1;
    }
