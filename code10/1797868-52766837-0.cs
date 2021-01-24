    string word = "Hello";
    string result = string.Empty;
    foreach(char c in word) //loop through each character of word
    {
        result +=  (char)(c + 2);  //Add 2 to character and append it to result after converting back to character
    }
    
    Console.WriteLine(result);
