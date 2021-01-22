    private void ChangeControlStatus(ControlCollection col, bool status)
     {
        foreach (Control ctrl in col)
            ChangeControlStatus(ctrl.Controls, status)
    
              if (ctrl is TextBox)
     
                ((TextBox)ctrl).Enabled = status;
    
              else if (ctrl is Button)
        
                ((Button)ctrl).Enabled = status;
    
              else if (ctrl is RadioButton)
    
                ((RadioButton)ctrl).Enabled = status;
    
              else if (ctrl is ImageButton)
    
                ((ImageButton)ctrl).Enabled = status;
    
              else if (ctrl is CheckBox)
    
                ((CheckBox)ctrl).Enabled = status;
    
              else if (ctrl is DropDownList)
    
                ((DropDownList)ctrl).Enabled = status; 
     
           else if (ctrl is HyperLink)
    
            ((HyperLink)ctrl).Enabled = status; 
    
     }
