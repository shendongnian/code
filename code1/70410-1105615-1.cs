    using System.IO;
    
    private String GetFileName(String hrefLink)
    {
        return Path.GetFileName(hrefLink.Replace("/", "\\"));
    }
