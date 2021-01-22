      //Add Miscellaneous Data Details
                data.ListNameEx = Settings.Default.SPListLoader_List_Name;
                //Instantiate the Web Service
                SPListService.Lists lists = new SPListLoaderService.SPListService.Lists();
                //Bind Appropriate Credentials to the Web Service
                lists.Credentials = new NetworkCredential(data.UserName, data.Password, data.Domain);
                //Set the List Object URI
                lists.Url = data.URI.TrimEnd('/') + "/_vti_bin/lists.asmx";
