    using System.IO;   
    public static string RandomStr()
    {
        string rStr = Path.GetRandomFileName();
        rStr = rStr.Replace(".", ""); // For Removing the .
        return rStr;
    }
