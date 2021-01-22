    //This assumes the datatables have the same schema...
    		public bool DatatablesAreSame(DataTable t1, DataTable t2) {			
    			if (t1.Rows.Count != t2.Rows.Count)
    				return false;
    
    			foreach (DataColumn dc in t1.Columns) {
    				for (int i = 0; i < t1.Rows.Count; i++) {
    					if (t1.Rows[i][dc.ColumnName] != t2.Rows[i][dc.ColumnName]) {
    						return false;
    					}
    				}
    			}
    			return true;
    		}
