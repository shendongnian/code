    class User
    {
        public string Name {get; set;}
        public string SurrName {get; set;}
        public string ToRequestContent()
        {
             return "&Name="+Name+"&Surrname="+SurrName;
        }
    }
    class Book
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string ToRequestContent()
        {
             return "&Id="+Id+"&Title="+Title;
        }
    }
