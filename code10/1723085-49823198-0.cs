    List<string> splitted = new List<string>();
    string fileList = results;
    string[] tempStr;
    
    tempStr = fileList.Split(new Char[] {'\n',','});
    int j = 0;
    foreach (string item in tempStr)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            splitted.Add(item);
            Console.WriteLine(splitted[j]);
            Console.ReadKey();
            j++;
        }
    }
