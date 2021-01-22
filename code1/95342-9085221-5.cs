    // Fluent class mapping:
    public sealed class MyCustomObjectMap : CsvClassMap<MyCustomObject>
    {
        public MyCustomObjectMap()
        {
            Map( m => m.StringProperty ).Name( "First Name" );
            Map( m => m.IntProperty ).Index( 0 );
            Map( m => m.ShouldIgnore ).Ignore();
        }
    }
