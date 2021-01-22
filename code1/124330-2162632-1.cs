    try
        {
    
        //Copy WebService Settings 
        string webUrl           = "http://sharepointportal.ABC.com/";
        WSCopy.Copy copyService = new WSCopy.Copy();
        copyService.Url         = webUrl + "/_vti_bin/copy.asmx";
        copyService.Credentials = new NetworkCredential("username", "****", "Domain");
        
        //Declare and initiates the Copy WebService members for uploading 
        
        string sourceUrl        = "C:\\Work\\Ticket.Doc";   
            
        //Change file name if not exist then create new one     
        string[] destinationUrl    = { "http://sharepointportal.ABC.com/personal/username/Document Upload/Testing Document/newUpload.Doc" };
        
        WSCopy.CopyResult cResult1 = new WSCopy.CopyResult();
        
        WSCopy.CopyResult cResult2 = new WSCopy.CopyResult();
        
        WSCopy.CopyResult[] cResultArray = { cResult1, cResult2 };
        
        WSCopy.FieldInformation fFiledInfo = new WSCopy.FieldInformation();
        
        fFiledInfo.DisplayName = "Description";
        
        fFiledInfo.Type        = WSCopy.FieldType.Text;
        
        fFiledInfo.Value       = "Ticket";
        
        WSCopy.FieldInformation[] fFiledInfoArray = { fFiledInfo }; 
        
        FileStream strm = new FileStream(sourceUrl, FileMode.Open, FileAccess.Read); 
        
        byte[] fileContents = new Byte[strm.Length]; 
        
        byte[] r = new Byte[strm.Length];
        
        int ia = strm.Read(fileContents, 0, Convert.ToInt32(strm.Length));
        strm.Close();
        //Copy the document from Local to SharePoint 
        
        uint copyresult = copyService.CopyIntoItems(sourceUrl, destinationUrl, fFiledInfoArray, fileContents, out cResultArray); 
        
        MessageBox.Show("Suceess");  
    
      }
     catch (Exception ex)    
     { 
        MessageBox.Show(ex.Message);
        
     }
