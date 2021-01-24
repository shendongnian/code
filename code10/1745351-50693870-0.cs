    string[] splitedString = input.Split('|');
            
    string[] resultArray = new string[splitedString.Length];
            
    int j = 0;
    for (int i = splitedString.Length - 1; i >= 0; i--)
    {
        resultArray[j] = splitedString[i].Trim();
        j++;
    }
    string result = string.Empty;
    foreach (string item in resultArray)
    {
        result += item + " ";
    }
    Console.WriteLine(result.Trim());
