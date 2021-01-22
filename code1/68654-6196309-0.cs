    static int SelectColumnIndex = 0;
    PerformAction_Click(object sender, System.EventArgs e)
    {
        string data = string.Empty;    
 
        foreach(DataGridViewRow row in MyDataGridView.Rows)     
        {
            if(row.Cells[SelectColumnIndex].Value != null 
                &&
             Convert.ToBoolean(row.Cells[SelectColumnIndex].Value) == true)       
            {
                foreach(DataGridViewCell cell in row.Cells)        
                {
                    if (cell.OwningColumn.Index != SelectColumnIndex)                               
                    {
                        data+= (cell.Value + " ") ; // do some thing           
                     }
                }
                data+="\n";
            }
        }
        MessageBox.Show(data, "Data");
    }
