    private void dataGridViewECO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {            
    
        if (e.ListChangedType != ListChangedType.ItemDeleted)
        {
    
            DataGridViewCellStyle green = this.dataGridViewECO.DefaultCellStyle.Clone();
            green.BackColor = Color.Green;
    
            DataGridViewCellStyle gray = this.dataGridViewECO.DefaultCellStyle.Clone();
            gray.BackColor = Color.LightGray;
    
    
                    
            foreach (DataGridViewRow r in this.dataGridViewECO.Rows)
            {
    
                if (r.Cells[8].Value != null)
                {
    
                    String stato = r.Cells[8].Value.ToString();
    
    
                    if (!" Open ".Equals(stato))
                    {
                        r.DefaultCellStyle = gray;
                    }
                    else
                    {
                        r.DefaultCellStyle = green;
                    }
                }
    
            }
    
        }
    }
