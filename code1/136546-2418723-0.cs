    public static class StringExtension
    {
        static public string ToStringFormatted(this DateTime dt)
        {
            return string.Format("{0:00}/{1:00}/{2:0000}", dt.Month, dt.Day, dt.Year);
        }
        // if the culture info change does fix your issue do:
        static public string ToStringFormatted2(this DateTime dt)
        {
            return dt.ToString("MM/dd/yyyy");
        }
    }
    // useage:
    string date = DateTime.Now.ToStringFormatted();
    // output:  03/10/2010
