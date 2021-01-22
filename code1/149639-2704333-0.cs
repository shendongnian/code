    public static bool TryGetValue<T>(this DataGridView dgv, int RowNo, 
        string ColName, out T cellValue)
    {
        cellValue = default(T);
        if (!dgv.Columns.Contains(ColName))
            return false;
        cellValue = (T)Convert.ChangeType(dgv.Rows[RowNo].Cells[ColName].Value, typeof(T));
        return true;
    }
    
    public static void Main(){
    int desiredValue;
    if(dataGridView.TryGetValue<int>(rowNumber, columnName, out desiredValue)){
    	//Use the value
    }
    else{
    	//Value can not be retrieved.
    }
    }
