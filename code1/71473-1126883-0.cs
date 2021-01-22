    `SPWeb Destinationsite = DestinationSiteCollection.OpenWeb();
    SPList DestinationList = Destinationsite.Lists[TASKS];    
    SPListItem DestinationListItem = DestinationList.Items.Add();
      foreach (DataRow row in sourceList.Rows)
    {
        DestinationListItem = DestinationList.Items.Add();
        DestinationListItem["Field1"]=row["Col"].ToString();
        DestinationListItem["Fieldn"]=row["Coln"].ToString();
        DestinationListItem.Update()
    }
