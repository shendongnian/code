    public static string ZipFile(String source, String target)
    {
        try 
        {
            using (ZipFile zip = new ZipFile()
            {
                zip.AddFile(source);
                zip.Save(target);
            }
            return "success";
        }
        catch {}
        return "failure";
    } 
