    string data = "THExxQUICKxxBROWNxxFOX";
    var dataspt = data.Split("xx");
    //>THE  QUICK  BROWN  FOX 
    //the extension class must be declared as static
    public static class StringExtension
    {   
        public static string[] Split(this string str, string splitter)
        {
            return str.Split(new[] { splitter }, StringSplitOptions.None);
        }
    }
