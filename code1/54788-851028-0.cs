    SPSite siteCollection = new SPSite("site url");
    SPWeb site = siteCollection.OpenWeb();
    
    foreach(SPGroup group in site.Groups){
      Console.WriteLine(group.Name);
        
       foreach(SPUser u in group.Users){
             //will give you users in group, you can then grab the roles of the user
       }
    }
