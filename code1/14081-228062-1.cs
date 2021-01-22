    public string Reverse(string text)
    {
       // this was posted by petebob as well 
       char[] array = text.ToCharArray();
       Array.Reverse(array);
       return new String(array);
    }
