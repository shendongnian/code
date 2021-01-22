    struct Range
    {
       public readonly int LowerBound;
       public readonly int UpperBound; 
    
       public Range( int lower, int upper )
       { LowerBound = lower; UpperBound = upper; }
    
       public bool IsBetween( int value )
       { return value >= LowerBound && value <= UpperBound; }
    }
    
    public void YourMethod( int someValue )
    {
       List<Range> ranges = {new Range(4199,6800),new Range(6999,8200),
                             new Range(9999,10100),new Range(10999,11100),
                             new Range(11999,12100)};
       if( ranges.Any( x => x.IsBetween( someValue ) )
       {
          // your awesome code...
       }
    }
