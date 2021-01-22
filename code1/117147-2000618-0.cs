    using System;
    using WatiN.Core;
    
    public static class WatiNExample
    {
    
        public static bool CheckUrlForText(string p_sUrl, string p_sText)
        {
            // Open a new Internet Explorer window and
            // go to the google website.
            IE ie = new IE(p_sUrl);
            
            try    
            {
                return ie.Text.Contains(p_sText));
            }
            finally
            {
                ie.Close();
            }
        }
    }
    
