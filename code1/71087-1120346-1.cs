    char ReplacementChar = ' '; //space
    string str = "string!$%with^&*invalid!!characters";
    Console.WriteLine( str ); //print original string
    fixed (char* p_str = str)
    {
        char* c = p_str; //temp pointer, since p_str is read-only
        for (int i = 0; i < str.Length; i++, c++) //loop through each character in string, advancing the character pointer as well
            if (IsInvalidChar(*c)) //check whether the current character is invalid
                (*c) = ReplacementChar; //overwrite character in existing string
    }
    Console.WriteLine( str ); //print string again to verify that it has been modified
            
