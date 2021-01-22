    private static Dictionary<String, String> mtypes = new Dictionary<string, string> {
            {".PDF", "application/pdf" },
            {".JPG", "image/jpeg"},
            {".PNG", "image/png"},
            {".GIF", "image/gif"},
            {".TIFF","image/tiff"},
            {".TIF", "image/tiff"}
        };
    static String MimeType(String filePath)
    {
        System.IO.FileInfo file = new System.IO.FileInfo(filePath);
        String filetype = file.Extension.ToUpper();
        if(mtypes.Keys.Contains<String>(filetype))
            return mtypes[filetype];
        return "image/" + filetype.Replace(".", "").ToLower();
    }
