        public DataTable compareConfigs(DataTable today, DataTable yesterday)
        {
            DataTable dtCurrent = today;
            DataTable dtLast = yesterday;
            dtLast.AcceptChanges();
            DataTable dtChanges = null;
            dtLast.Merge(dtCurrent, true);
            dtChanges = dtLast.GetChanges(DataRowState.Unchanged);
            return dtChanges;
        }
        
    static void Main(string[] args)
        {
            // Declaring the DataSets
            DataSet dataSet = new DataSet();
            DataSet dataSet2 = new DataSet();
            
            // reading in an XML file to DataTable
            dataSet.ReadXml(@"Path to saved XML query");
            DataTable yesterday = dataSet.Tables[0];
            yesterday.PrimaryKey = new DataColumn[] { yesterday.Columns["Key"]};
            // reading in an xml file to datatable
            dataSet2.ReadXml(@"Path to saved XML query");
            DataTable today = dataSet2.Tables[0];
            today1.PrimaryKey = new DataColumn[] { today1.Columns["Key"]};
            ConfigCompare comp = new ConfigCompare();
            DataTable mismatch = comp.compareConfigs(today, yesterday);
        }
    }
