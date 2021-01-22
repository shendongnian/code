    interface IDataRow {
      string GetDataSTructre();  // How to read data from the DB
      void Read(IDBDataRow);     // How to populate this datarow from DB data
    }
    public class DataTable<T> : List<T> where T : IDataRow {
      public string GetDataStructure()
        // Desired: Static or Type method:
        // return (T.GetDataStructure());
        // Required: Instantiate a new class:
        return (new T().GetDataStructure());
      }
    }
