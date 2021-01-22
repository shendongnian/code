    public bool Enabled
    {  
      set 
      {  
          r1.Enabled = r1.Checked? value || r1.Enabled: value;   
          r2.Enabled = r2.Checked? value || r2.Enabled: value;   
      }
    }
