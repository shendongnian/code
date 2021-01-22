    //we init this once so that if the function is repeatedly called
    //it isn't stressing the garbage man
    private static Regex dateTakenHelperRegex = new Regex(":");
    public static DateTime GetDateTakenFromImage(string path)
    {
        using (Image myImage = Image.FromFile(path)) 
        {
            PropertyItem propItem = myImage.GetPropertyItem(36867);
            string dateTaken = dateTakenHelperRegex.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
            return DateTime.Parse(dateTaken);
        }
    }
