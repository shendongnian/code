    using SQLite; // Here using sqlite-net-pcl
    using System.Collections.Generic;
    namespace SQLiteEx
    {
      class SQLiteConnection : SQLite.SQLiteConnection
      {
        // Must provide a constructor with at least 1 argument
        public SQLiteConnection(string path)
          : base(path)
        {
        }
        // With this class, you can automatically append 
        // some kind of global filter like LIMIT 1000 
        string mGlobalFilter = "";
        public string GlobalFilter
        {
          set { mGlobalFilter = value; }
          get { return string.IsNullOrWhiteSpace(mGlobalFilter) ? "" : " " + mGlobalFilter; }
        }
        // You MUST constrain the generic type with "where T : new()"
        // OTHERWISE feel the wrath of:
        // ===================================================================
        //  'T' must be a non-abstract type with a public parameterless 
        //  constructor in order to use it as parameter 'T' in the generic 
        //  type or method 'SQLiteConnection.Query<T>(string, params object[])'
        // ===================================================================
        public List<T> Query<T>(string sql) where T : new()
        {
          return base.Query<T>(sql + GlobalFilter);
        }
      }
    }
