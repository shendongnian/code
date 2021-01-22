     private void dgMapTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                    double newInteger;
                    if(double.TryParse(dgMapTable[e.ColumnIndex,e.RowIndex].Value.ToString(),out newInteger)
                    {
                     if (newInteger < 0 || newInteger > 50)
                     {
                       dgMapTable[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red; 
                       dgMapTable[e.ColumnIndex, e.RowIndex].ErrorText = "Keep value in Range:" + "0 to " + "50";
                     }
                    }                               
            }
