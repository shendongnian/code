       if (InstalledListNodes != null)
       {
           var attribute = InstalledListNodes.Attributes["title"]; 
           if (attribute != null)
           {
               if (attribute.InnerText.Equals(packagename) == true)
               {
                  // ...
               }
           }
       }
