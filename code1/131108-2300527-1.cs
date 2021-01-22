    public void UpdateControls()
      {
        List<string> filesDataSource = GetFiles(); // replace with your Datasource
        
        Control1.DataSource = filesDataSource ;
        Control2.DataSource = filesDataSource ;
        Control3.DataSource = filesDataSource ;
        
        Control1.DataBind();
        Control2.DataBind();
        Control3.DataBind();
      }
      Control1_SelectedIndexChanged(.............) // Replace with your evnents
      {
       // 
       //
       UpdateControls();
      }
