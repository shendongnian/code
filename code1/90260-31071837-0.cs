        string originalString = "1111222233334444";
        List<string> test = new List<string>();
        int chunkSize = 4; // change 4 with the size of strings you want.
        for (int i = 0; i < originalString.Length; i = i + chunkSize)
        {
            if (originalString.Length - i >= chunkSize)
                test.Add(originalString.Substring(i, chunkSize));
            else
                test.Add(originalString.Substring(i,((originalString.Length - i))));
        }
