    private void clearButton_click(object sender, EventArgs e)  
    {    
        foreach (Control c in this.Controls)   
        {  
            CheckBox cb = c as CheckBox;  
            if (cb != null)  
            {  
                cb.Checked = false;  
            }
        }
    }
