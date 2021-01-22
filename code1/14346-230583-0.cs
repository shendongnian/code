    string foo = Console.ReadLine();
    string[] tokens = foo.Split(",");
    List<int> nums = new List<int>();
    int oneNum;
    foreach(string s in tokens)
    {
        if(Int32.TryParse(s, out oneNum))
            nums.Add(oneNum);
    }
