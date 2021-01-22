    class TableModel extends AbstractTableModel
    {
        String[] columnNames = {“FirstName”,”LastName”,”Title”};
        Object[][] rowData= {{‘John,”Smith”,”President”},{“John”,”Doe”,”Employee”}};
        public int getColumnCount()
        {
            return columnNames.length;
        }
        public int getRowCount()
        {
            return rowData.length;
        }
        public String getColumnName(int col)
        {
            return columnNames[col];
        }
        public Object getValueAt(int row, int col)
        {
            return data[row][col];
        }
    }
