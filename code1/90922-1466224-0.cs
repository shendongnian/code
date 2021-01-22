    public class DataGridViewExt : DataGridView  
    {
        public void HideColumns(params string[] columnNames)
        {
            foreach (string str in columnNames)
            {
                if (this.Columns[str] != null)
                {
                    this.Columns[str].Visible = false;
                }
            }
        }        
    }
