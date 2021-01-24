    [DelimitedRecord(";")]
    public class MigrationFlags
    {   
        // Extremely simple class.
        // Only the fields in the CSV
        // No logic. Nothing clever.
        public string RelativeUrl { get; set;};
    }
    public class MigrationClass
    {   
        // A normal C# class with:
        //   constructors
        //   properties
        //   methods
        //   readonly, if you like
        //   inheritance, overrides, if you like
        // etc.
        public string Url { get; set; }
        public string RelativeUrl => UriExt.GetRelativeUrl(this.Url);
    }
