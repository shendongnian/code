    class Row
    {
        public Y1 {get;set;}
        public Y2 {get;set;}
        public Name {get;set;}
    }
    
    var list = new List<Row>();
    //fill list
    
    var result = list.Where(o => o.Y1 <= x && x < o.Y2).First();
