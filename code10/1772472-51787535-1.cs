    public static class TablesClass
    {
        //Search source code of your Nuget package, find its base class of Generic class, the list must be defined as its base
        private static IList<Tables> Tables { get; set; }
        static TablesClass()
        {
            Tables = new List<Tables>();
        }
        public static void AddTable(Tables table)
        {
            Tables.Add(table);
        }
    }
