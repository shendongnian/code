    class Program
    {
        static void Main( string[] args )
        {
            List<int> values = new List<int>();
            values.Add( 10 );
            values.Add( 15 );
            values.Add( 20 );
            List<string> groups = new List<string>();
            groups.Add( "col1" );
            groups.Add( "col2" );
            groups.Add( "col3" );
            groups.Add( "col4" );
            groups.Add( "col5" );
            values.Expand( groups.Count );
            Console.WriteLine( string.Join( ", ", values ) );
        }
    }
