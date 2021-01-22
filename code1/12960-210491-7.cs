    public static ReadOnlyCollection<char> GetInvalidPathChars(){
       return Array.AsReadOnly(InvalidPathChars);
    }
    
    public static char[] GetInvalidPathChars(){
       return (char[])InvalidPathChars.Clone();
    }
