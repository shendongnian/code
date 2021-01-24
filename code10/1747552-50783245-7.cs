    static void Main(string[] args)
    {
        string str1 = "Q";
        string str2 = "q";
     
        if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase)) { }
       
        string menu = "";
     
        do
        {
            Console.WriteLine("Select Meun:(1)Triangle (2)Rectangle " +
                    "(Q)Quit",string.Equals
                    (str1, str2, 
                    StringComparison.CurrentCultureIgnoreCase));
        
            menu = Console.ReadLine();
        
            Console.WriteLine(menu + "is selected");
        } while (!string.Equals(menu, "Q", StringComparison.OrdinalIgnoreCase));
    }
