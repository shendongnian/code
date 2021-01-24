    public static SharePointSiteObject SharePointDeserialize(string jObject)
    {
        SharePointSiteObject sharePointSite;
        sharePointSite = JsonConvert.DeserializeObject<SharePointSiteObject>(jObject);
        return peopleList.FirstOrDefault();
    }
