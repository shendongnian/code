    interface IColumnTypeParser
    {
        // A stateles Parse method that takes input and returns output
        DataColumn Parse(string input);
    }
    
    class ColumnTyeParserFactory
    {
        IColumnTypeParser GetParser(Type columnType)
        {
            // Implementation can be anything you want...I would recommend supporting
            // a configuration file that maps types to parsers, and use pooling or caching
            // so you are not constantly recreating instances of your parsers (make sure your
            // parser implementations are stateless to support caching/pooling and reuse)
    
            // Dummy implementation:
            if (columnType == typeof(string)) return new StringColumnTypeParser();
            if (columnType == typeof(float)) return new FloatColumnTypeParser();
            // ...
        }
    }
