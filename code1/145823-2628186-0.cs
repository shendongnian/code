    public static DataView getLatestFourActive() {
		DataTable productDataTable = getAll().ToTable();
        DataTable cloneDataTable = productDataTable.Clone();
		
        for (int i = 0; i < 4; i++) {
            cloneDataTable.ImportRow(productDataTable.Rows[i]);
        }		
        return new DataView(cloneDataTable);
    }
