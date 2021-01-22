    public partial class DataSet1 {
        partial class DataTable1DataTable
        {
            public string MyStringColumn {
                get {
                    return IntColumn <= 0 ? "Na/Na" : IntColumn.ToString();
                } 
            }
        }
    }
