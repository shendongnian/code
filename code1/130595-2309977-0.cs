    public class Visitor {
         History history;
         public visit ( ResultItem1 item )  { ... }
         public visit ( ResultItem2 item )  { ... }
         ...
    }
    public class ResultItem1 {
         public accept( Visitor v ) { v.visit( this ); }
    }
