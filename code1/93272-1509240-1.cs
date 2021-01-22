    Lists.Lists ls = new Lists.Lists();
    ls.PreAuthenticate = true;
    ls.Credentials = System.Net.CredentialCache.DefaultCredentials;
    ls.Url = SharePointSiteURL + @"/_vti_bin/lists.asmx";
    
    string DocID = GetDocumentID(ls, ListGUID, FileName);
