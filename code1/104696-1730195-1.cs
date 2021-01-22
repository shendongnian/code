    public static class IEnumerableExtensions
    {
        // reasonable to assume you will use this everywhere, not just
        // Sql statements, but log statements, anywhere you need to 
        // dump a list into a readable format!
        // 
        // HINT: extra credit: you can generalize this, and provide
        // specialized short hands that invoke the general method
        public static string ToCommaSeparatedString<T>(this IEnumerable<T> values)
        {
             // SIGH: so apparently this does not generate minimal
             // assembler on every machine, please note the following
             // is written for clarity, please feel free to substitute
             // your own favourite ultra-performance high-octance
             // string appender algorithm
             StringBuilder commaSeparated = new StringBuilder ();
             foreach (T value in values)
             {
                 // PERF: store format string as const
                 commaSeparated.AppendFormat ("{0}, ", value);
             }
             // PERF: store trim chars as static readonly array
             return commaSeparated.Trim (", ".ToCharArray ());
        }
    }
    ...
    // elsewhere in code
    List<int> myIdentifiers = new List<int> { 1, 2, 3, 4, 5, };
    string mySqlIdentifierList = myIdentifiers.ToCommaSeparatedList ();
    string mySqlStatementFormat = "SELECT * FROM [SomeTable] WHERE [Id] IN ({0})";
    string mySqlStatement = 
        string.format (mySqlStatementFormat, mySqlIdentifierList);
    ...
