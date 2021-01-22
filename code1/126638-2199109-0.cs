    public class MySorter : IComparer<ISilverNodeModelClass>
    {
       public int Compare( ISilverNodeModelClass left, ISilverNodeModelClass right )
       {
           if( left.Label.Equals (right.Label) )
               return 0;
           if( left.Label == "malcolm" || left.Label == "sandra" )
              return Int32.MinValue;
    
           if( right.Label == "malcolm" || right.Label == "sandra" )
               return Int32.MaxValue;
    
           return Comparer<string>.Default.Compare (left.Label, right.Label);
       }
    }
