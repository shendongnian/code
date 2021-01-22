    using System;
    using System.Data;
    using System.Collections;
    using System.Data.Common;
    
    namespace TypedDataSet {
    
      public class Employees : BaseModel<Employee> {
    
        public Employees(bool loadAll) {
            DbDataAdapter adapter = base.Adapter("SELECT * FROM Employees");
            adapter.Fill(this);
        }
    
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
            return new Employee(builder);
        }
      }
    
      public class Employee : DataRow {
        internal Employee(DataRowBuilder builder)
          : base(builder) {
        }
    
        public Int64 Id {
          get { return (Int64)base["Id"]; }
          set { base["Id"] = value; }
        }
    
        public string FirstName {
          get { return (string)base["Firstname"]; }
          set { base["Firstname"] = value; }
        }
    
        public string Surname {
          get { return (string)base["Surname"]; }
          set { base["Surname"] = value; }
        }
      }
    }
