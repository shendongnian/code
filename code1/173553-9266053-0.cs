    namespace Software_Info_v1._0
    {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Office.Interop;
    public class MS_Office
    {
        public string GetOfficeVersion()
        {
            string sVersion = string.Empty;
            Microsoft.Office.Interop.Word.Application appVersion = new Microsoft.Office.Interop.Word.Application();
            appVersion.Visible = false;
            switch (appVersion.Version.ToString())
            {
                case "7.0":
                    sVersion = "95";
                    break;
                case "8.0":
                    sVersion = "97";
                    break;
                case "9.0":
                    sVersion = "2000";
                    break;
                case "10.0":
                    sVersion = "2002";
                    break;
                case "11.0":
                    sVersion = "2003";
                    break;
                case "12.0":
                    sVersion = "2007";
                    break;
                case "14.0":
                    sVersion = "2010";
                    break;
                default:
                    sVersion = "Too Old!";
                    break;
            }
            Console.WriteLine("MS office version: " + sVersion);
            return null;
        }
    }
    }
