    Int64[] aValues = new Int64[] { long.MaxValue - 100, long.MaxValue - 200, long.MaxValue - 300 };
    
    List<RationalNumber> list = new List<RationalNumber>();
    Int64 nAverage = 0;
    
    for ( Int32 i = 0; i < aValues.Length; ++i )
    {
    	Int64 nReminder = aValues[ i ] % aValues.Length;
    	Int64 nWhole = aValues[ i ] / aValues.Length;
    
    	nAverage += nWhole;
    
    	if ( nReminder != 0 )
    	{
    		list.Add( new RationalNumber() { Dividend = nReminder, Divisor = aValues.Length } );
    	}
    }
    
    RationalNumber rationalTotal = new RationalNumber();
    
    foreach ( var rational in list )
    {
    	rationalTotal += rational;
    }
    
    nAverage = nAverage + ( rationalTotal.Dividend / rationalTotal.Divisor );
