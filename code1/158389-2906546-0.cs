    partial class DataClassesDataContext
        public DataClassesDataContext()
             : this(ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString) {
        }
    }
