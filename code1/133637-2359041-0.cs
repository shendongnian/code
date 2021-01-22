    public object DataSource
    {
       get 
       {
           this.EnsureChildControls();
           return gv.DataSource; 
       }
       set 
       { 
           this.EnsureChildControls();
           gv.DataSource = value; 
       }
    }
