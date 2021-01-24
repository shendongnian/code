    //Split your string to string[] by given separator
    string[] splitedString = input.Split('|');
            
    //create new array to store your result values
    string[] resultArray = new string[splitedString.Length];
            
    //loop backwards through your array and store your values into new array (resultArray)
    for (int i = splitedString.Length - 1, j = 0; i >= 0; i--, j++)
    {
        resultArray[j] = splitedString[i].Trim();
    }
    //Iterate through new array and construct new string from existing values, 
    //method Trim() is removing leading and trailing whitespaces
    string result = string.Empty;
    foreach (string item in resultArray)
    {
        result += item + " ";
    }
    Console.WriteLine(result.Trim());
