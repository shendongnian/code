    public class Department : DataSet.DepartmentRow {
        public Department(global::System.Data.DataRowBuilder DataRowBuilder rb) : base(rb, "discard") { }
        public List<Employee> Employees;
        public string[] SomeFrequentlyUsedGroupOfFields {
            get {
                return new string[] { this.OneField, this.AnotherField };
            }
        }
        public bool CanUserSeeDepartmentInformation(int UserID) { }
    }
