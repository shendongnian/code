    ItemUpdated(SPItemEventProperties properties)
    { 
      //...
      string url = properties.Web.Site.Url + "/" + properties.Web.Name + "Lists/ListName/" + properties.ListItem.File.Name;
      //properties.ListItem.File.MoveTo(url);
      properties.ListItem.File.CopyTo(url);
      //...
    }
 
