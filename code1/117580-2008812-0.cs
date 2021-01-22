    public class HtmlTable<T> where T : class 
    { 
        List<T> listToConvert; 
     
        public HtmlTable(List<T> listToConvert) 
        { 
            this.listToConvert = listToConvert; 
        } 
    } 
    
    [ComVisible(true)]
    public class StringHtmlTable : HtmlTable<String>
    {
        // implementation goes here
    }
