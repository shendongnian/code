    static void Main() {
        DelegateList<int> delegates = new DelegateList<int>();
        delegates.Add( PrintInt );
        delegates.CallDelegates( 42 );
    }
    static void PrintInt( int i ) {
        Console.WriteLine( i );
