    using (SPSite site = new SPSite("http://YOUR URL"))
    {
      using (SPWeb web = site.OpenWeb()) 
      {
        SPList list = web.Lists["news"];
    
        SPListItem item = list.Items.Add();
        DateTime dt = DateTime.Now;
    
        item["Title"] = "Test";
        item["Expires"] = dt;
    
        item.Update();
      }
    }
