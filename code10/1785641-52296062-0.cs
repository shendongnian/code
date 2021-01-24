    class Record 
    {
        public string Telephone {get;set;}
        ...
    }
    var items = text.Split('$');
    var record=new Record 
               {
                   Telephone=items[0],
                   Mobile=items[1],
                   ...
               };
    
