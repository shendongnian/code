    public static class MyObjectExtensions
    {
        public static bool IsMatchFor(this string property, string ddlText, bool chkValue)
        {
            if(ddlText!=null && ddlText!="")
            {
                return property!=null && property.Contains(ddlText);
            }
            else if(chkValue==true)
            {
                return property==null || property=="";
            }
            // no filtering selected
            return true;
        }
    }
