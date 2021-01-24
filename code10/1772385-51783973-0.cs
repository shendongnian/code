    FileUpload Fu1 = up1;
    
    string timek = System.DateTime.Now.Ticks.ToString();
    string virtualFolder = "Upload/" + timek;
    string physicalFolder = Server.MapPath(virtualFolder);
    
    Fu1.SaveAs(physicalFolder + Fu1.FileName);  
                  
    timek = timek + Fu1.FileName;
    
    HiddenField1.Value ="http://www.Teacher.com/Upload/" + timek;
