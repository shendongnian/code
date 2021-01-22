     private Machine CurrentMachine { get; set; }
     public void Machine_DataBound(object sender, RepeaterItemEventArgs e)
     {
         CurrentMachine = e.Item as Machine;
     }
