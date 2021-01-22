    public static ReadOnlyCollection<char> GetInvalidPathChars(){
       return Array.AsReadOnly(badChars);
    }
    
    public static char[] GetInvalidPathChars(){
       return (char[])badChars.Clone();
    }
