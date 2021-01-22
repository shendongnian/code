    public class HGrid
    {
        public static void MakeComboBoxColumn(ref DataGridViewComboBoxColumn col, List<string> values)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("f_Id").DataType = typeof(Int32);
            dt.Columns[0].DataType = typeof(Int32);
            dt.Columns.Add("f_Desc");
            dt.Columns[1].DataType = typeof(string);
    
    
            for (int i = 0; i < values.Count; i++)
            {
                dt.Rows.Add(i, values[i]);
            }
    
            col.DataSource = dt;
            col.DisplayMember = dt.Columns[1].ColumnName;
            col.ValueMember = dt.Columns[0].ColumnName;
        }
    }
