    private void AddCustomWebPartToAllPages()
    {
      using(SPSite site = new SPSite("http://sharepoint"))
      {
        GetWebsRecursively(site.OpenWeb());
      }
    }
    private void GetWebsRecursively(SPWeb web)
    {
      //loop through all pages in the SPWeb's Pages library
      foreach(var item in web.Lists["Pages"].Items)
      {
        SPFile f = item.File;
        SPLimitedWebPartManager wpm = f.GetLimitedWebPartManager(PersonalizationScope.Shared);
        //ADD YOUR WEBPART
        YourCustomWebPart wp = new YourCustomWebPart();
        wp.YourCustomWebPartProperty = propertyValue;
        wpm.AddWebPart(wp, "ZONEID", 1);
        f.Publish("Added Web Part");
        f.Approve("Web Part addition approved");
      }
      // now do this recursively
      foreach(var subWeb in web.Webs)
      {
        GetWebsRecursively(subWeb);
      }
      web.Dispose();
    }
