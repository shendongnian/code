    IMyDatabase
    {
    BbSet<Model1> Model1{get;set;}
    BbSet<Model2> Model2{get;set;}
    }
    TnsDb:IMyDatabase
    {
    BbSet<Model1> Model1{get;set;}
    BbSet<Model2> Model2{get;set;}
    }
    SngDb:IMyDatabase
    {
    BbSet<Model1> Model1{get;set;}
    BbSet<Model2> Model2{get;set;}
    }
