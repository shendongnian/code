        using System.IO;   
    
        string fileName = Path.Combine(Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt")
            JObject ph1json; 
            bool doesExist = File.Exists(fileName);
            if(!doesExist || string.IsNullOrEmpty(crphoto1))   
            {
             ph1json = new JObject
             {
               {"ContactID", crcontactID},
               {"Photo1", ""}
              }
            }
            else
            { 
              ph1json = new JObject
             {
               {"ContactID", crcontactID},
               {"Photo1", File.ReadAllBytes(crphoto1)}
             };
