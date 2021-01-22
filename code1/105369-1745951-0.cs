       if (InstalledListNodes != null)
       {
           var attribute = InstalledListNodes.Attributes["title"]; 
           if (attribute != null)
           {
               string innerText = attribute.InnerText;
               if (innerText != null && innerText.Equals(packagename) == true)
               {
                  // ...
               }
           }
       }
