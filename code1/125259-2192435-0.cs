            Lists listService            = new Lists();
            listService.PreAuthenticate  = true;
            listService.Credentials      = new NetworkCredential(username,password,domain;
            String url                   = "http://YourServer/SiteName/"; // put your desired path here 
            listService.Url              = url @ + /_vti_bin/lists.asmx";
    
            XmlNode ndList               = listService.AddList(NewListName, "Description", 100);
