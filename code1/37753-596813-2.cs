    protected void Chart_Click(object sender, ImageMapEventArgs e)
    {
        Chart chart = (Chart)sender;
        control c = Parent.FindControl(chart.ID + "UP");
        UpdatePanel up ;
       
        if (c != null)
        {
           up = c as UpdatePanel;**
      
    
           GridView gv = new GridView();
           Dictionary<string, string> displayFields =
               new Dictionary<string, string>();
    
           // add data to displayFields by using the ImageMapEventArgs.PostBackValue
           // to create data for dictionary ...
    
           gv.DataSource = displayFields;
           gv.DataBind();
           up.ContentTemplateContainer.Controls.Add(gv);
       }
    }
