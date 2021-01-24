     public void CopyDuplications(bool Overwrite)
     {
        if (!Overwrite)
          return "OK";
        else 
        {
            string Destination = Session["Destination"] as string;
            var DuplicatedFiles = Session["DouplicatedFiles"] as List<string>();
            for (int i = 0; i< DuplicatedFiles.Count; i++) 
            {
                string DestinationFilePath = System.IO.Path.Combine(Destination, System.IO.Path.GetFileName(DuplicatedFiles[i]));
                
                System.IO.File.Copy(DuplicatedFiles[i], DestinationFilePath, true);
            }
        }  
     }   
