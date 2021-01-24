     bool result = true;
     for(int i=0; i<this.Controls.Count; i++)
     { 
        if (this.Controls[i] is CheckBox)
        {
            if ((this.Controls[i] as CheckBox).Checked == false)
            {  result = false; break; } 
        }
     }
