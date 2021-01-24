    public static void ClearNav()
    {
       navHomeTabPage.Icon = "";
       navHomeTabPage.Title = "";
       navHomeTabPage.IsEnabled=false;
       // more items
    }
    
    public static void SetNav()
    {
       navHomeTabPage.Icon = "home.png";
       navHomeTabPage.Title = "Home";
       navHomeTabPage.IsEnabled=true;
       // more items
    }
