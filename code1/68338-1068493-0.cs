    using System;
    using System.Text;
    using System.Xml;
    using System.IO;
    public static class FormatXML
    {
        public static string FormatXMLString(string sUnformattedXML)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXML);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xd.WriteTo(xtw);
            }
            finally
            {
                if(xtw!=null)
                    xtw.Close();
            }
            return sb.ToString();
        }
    }
