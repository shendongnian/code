    public partial class Spotlight
    {
       public string WellFormattedDescription()
       {
         //all the logic to return a well formatted Spotlight.Description
        string desc = Regex.Replace(Regex.Replace(this.Description, "<[^>]*>", 
                                     string.Empty), "[\0x0020\r\n]+", " ")
                           .TrimEnd();
        if (desc.Length < 297)
           return desc;
        else 
           return desc.Substring(0, 297) + "...";
       }
    }
