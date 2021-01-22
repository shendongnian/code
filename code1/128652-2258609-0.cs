    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Reflection;
    
    namespace Helpers
    {
        internal class EmailHelper
        {
            public static string GetSenderEmailAddress(Microsoft.Office.Interop.Outlook.MailItem mapiObject)
            {
                Microsoft.Office.Interop.Outlook.PropertyAccessor oPA;
                string propName = "http://schemas.microsoft.com/mapi/proptag/0x0065001F";
                oPA = mapiObject.PropertyAccessor;
                string email = oPA.GetProperty(propName).ToString();
                return email;
            }
        }
    }
