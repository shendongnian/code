    public string GetArrayString(string token)
    {
        //Here you split
        string[] arr = token.Split('|');
        StringBuilder sb = new StringBuilder();
        //Use for loop in reverse order, as you want to reverse the string 
        for(int i = arr.Length - 1; i >= 0; i--)
        {
          //Append result to stringbuilder object with " "
          sb.Append(arr[i].Trim() + " ");
        }
        //Convert string builder object to string and return to the main function
        return sb.ToString().Trim();
    }
       public static void Main(string[] args)
       { 
          //Read inputs from user in your case it is 1 2 3 |4 5 6 | 7 8
           string token = Console.ReadLine();
          //Here function will return expected output; note you need to create instance of class otherwise assign GetArrayString method as a static
           Console.WriteLine(GetArrayString(string token));
       } 
