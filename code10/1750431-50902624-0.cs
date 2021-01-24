    public static void Main()     
    {     
         string s = "Welcome to 2018";     
         int sumofInt = 0;     
           for (int i = 0; i < s.Length; i++)     
           {     
               int val = (int)Char.GetNumericValue(s[i]);
               if (Char.IsDigit(val))     
               {     
                   sumofInt += Convert.ToInt32(val);     
               }     
           }     
        Console.WriteLine(sumofInt);     
    
    }   
