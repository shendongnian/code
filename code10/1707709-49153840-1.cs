    public sealed class MyNodeDPCountMap : CsvClassMap<NodeDPCount>
    {
        public MyNodeDPCountMap()
        {
            Map( m => m.Id ).Index( 0 );
            Map( m => m.Name ).Index( 1 );
            // etc.
        }
    }
