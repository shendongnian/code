    public bool Enabled
    {  
      set  {  
             r1.Enabled = !r1.Checked? value: value || r1.Enabled;   
             r2.Enabled = !r2.Checked? value: value || r2.Enabled;   
           }
    }
