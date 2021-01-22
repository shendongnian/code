    public sealed class MyCustomObjectMap : CsvClassMap<MyCustomObject>
    {
        public MyCustomObjectMap()
        {
            Map( m => m.Property1 ).Name( "Column Name" );
            Map( m => m.Property2 ).Index( 4 );
            Map( m => m.Property3 ).Ignore();
            Map( m => m.Property4 ).TypeConverter<MySpecialTypeConverter>();
        }
    }
