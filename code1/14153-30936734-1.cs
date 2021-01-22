    static String Reverse(string str)
    {     
        char[] charA = str.ToCharArray();
        Array.Reverse(charA);
        return new String(charA);
    }
