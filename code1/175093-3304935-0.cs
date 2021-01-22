    string archiveListUrl = "http://myserver/Archive/";
    SPSite site;
    SPWeb web;
    SPDocumentLibrary library;
    
    using (site = new SPSite(archiveListUrl))
    using (web = site.OpenWeb())
    {
       library = (SPDocumentLibrary)web.Lists["Archive"];
       web.Folders.Add(archiveListUrl + "Help");
       web.Folders.Add(archiveListUrl + "News");
       web.Folders.Add(archiveListUrl + "Doc");
       web.Folders.Add(archiveListUrl + "New Doc Library");
       library.Update();
    }
