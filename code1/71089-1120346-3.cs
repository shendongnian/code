    static void Main(string[] args)
    {
        string str = "string!$%with^&*invalid!!characters";
        Console.WriteLine( str ); //print original string
        FixMyString( str, ' ' );
        Console.WriteLine( str ); //print string again to verify that it has been modified
        Console.ReadLine(); //pause to leave command prompt open
    }
    public static unsafe void FixMyString( string str, char replacement_char )
    {
        fixed (char* p_str = str)
        {
            char* c = p_str; //temp pointer, since p_str is read-only
            for (int i = 0; i < str.Length; i++, c++) //loop through each character in string, advancing the character pointer as well
                if (!IsValidChar(*c)) //check whether the current character is invalid
                    (*c) = replacement_char; //overwrite character in existing string with replacement character
        }
    }
    
    public static bool IsValidChar( char c )
    {
        return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == '.' || c == '_');
        //return char.IsLetterOrDigit( c ) || c == '.' || c == '_'; //this may work as well
    }
            
