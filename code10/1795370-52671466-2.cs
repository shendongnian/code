    DirectoryInfo dir = new DirectoryInfo(sExportPath);
    FileInfo[] Files = dir.GetFiles("*.csv"); 
    foreach(FileInfo file in Files )
    {
       // rename file
       System.IO.File.Move(file.FullName, GenerateNewFileName());
    }
    //elsewhere in the class
    private string GenerateNewFileName()
    {
        //here is where you implement creating or getting the filename that you want your file to be renamed to. An example might look like the below
        string serialNumber = GetSerialNumber(); //Get the serial number that you talked about in the question. I've made it a string, but it could be an int (it should be a string)
        return Path.ChangeExtension(serialNumber,".xls"); //to use path you will need a using statement at the top of your class file 'using System.IO'
    }
