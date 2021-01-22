                using (var service = new SharePoint.Services.ListsSoapClient())
                {
                    service.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                    var listName = "MyList";
                    var xelement = service.GetList(listName);
                    var fieldName = "Category"; //My Field name
                    XNamespace ns = "http://schemas.microsoft.com/sharepoint/soap/";
                    var selectedField = xelement.Descendants(ns + "Fields").Elements().Where(x => x.Attribute("Name").Value == fieldName).FirstOrDefault();
                    if (selectedField != null)
                    {
                        var choices = selectedField.Elements(ns + "CHOICES").Elements().Where(x => x.Name == ns + "CHOICE").Select(x => x.Value).ToList();
                        //Do something with choices
                    }
                }
