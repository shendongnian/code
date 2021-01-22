    try{
        string tempFile=System.IO.Path.GetTempFileName();
        string file=System.IO.Path.GetFileName(tempFile);
        //use file
        System.IO.File.Delete(tempFile);
    }catch(IOException ioe){
      //handle 
    }catch(FileIOPermission fp){
      //handle
    }
 
