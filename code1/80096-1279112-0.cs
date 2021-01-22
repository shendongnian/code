    /// Generates a string and checks for existance
    /// <returns>Non-existant string as ID</returns>
    public static string GetRandomNumbers(int numChars, string Type)
    {
        string result = string.Empty;
        bool isUnique = false;
        while (!isUnique)
        {
            //Build the string
            result = MakeID(numChars);
            //Check if unsued
            isUnique = GetValueExists(result, Type);
        }
        return result;
    }
    /// Builds the string
     public static string MakeID(int numChars)
    {
        string random = string.Empty;
        string[] chars = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        Random rnd = new Random();
        for (int i = 0; i < numChars; i++)
        {
            random += chars[rnd.Next(0, 35)];
        }
        return random;
    }
    /// Checks database tables based on type for existance, if exists then retry
    /// <returns>true or false</returns>
    private static bool GetValueExists(string value, string Type)
    {
        bool result = false;
        string sql = "";
        if (Type == "URL")
        {
            sql = string.Format(@"IF EXISTS (SELECT COUNT(1) FROM myTable WHERE uniqueString = '{0}')
             BEGIN
                 SELECT 1
             END
              ELSE
              BEGIN
                 SELECT 0
             END ", value);
        }
        //query the DB to see if it's in use
        result = //ExecuteSQL
        return result;
    }
