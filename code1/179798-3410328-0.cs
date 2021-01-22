    public string sendFileToWebService(string file)
    {
        string dirname = HttpContext.Current.Request.PhysicalApplicationPath + "\\Attachments\\";
        if (!System.IO.Directory.Exists(dirname))
        {
            System.IO.Directory.CreateDirectory(dirname);
        }
        string filename = dirname + "/" + "file.sim";
        byte[] byteArray = Convert.FromBase64String(file);
        File.WriteAllBytes(filename, byteArray ); //might wanna catch exceptions that could occur here
        return "Webservice says OK";
    }
