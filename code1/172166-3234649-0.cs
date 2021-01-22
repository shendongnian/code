    public static class SPListItemCollectionExtensions
        {
            public static readonly string xsltFromZRowToXml =
                    "<xsl:stylesheet version=\"1.0\" " +
                     "xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" " +
                     "xmlns:s=\"uuid:BDC6E3F0-6DA3-11d1-A2A3-00AA00C14882\" " +
                     "xmlns:z=\"#RowsetSchema\">" +
                 "<s:Schema id=\"RowsetSchema\"/>" +
                 "<xsl:output method=\"xml\" omit-xml-declaration=\"yes\" />" +
                 "<xsl:template match=\"/\">" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;rows&gt;</xsl:text>" +
                  "<xsl:apply-templates select=\"//z:row\"/>" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;/rows&gt;</xsl:text>" +
                 "</xsl:template>" +
                 "<xsl:template match=\"z:row\">" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;row&gt;</xsl:text>" +
                  "<xsl:apply-templates select=\"@*\"/>" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;/row&gt;</xsl:text>" +
                 "</xsl:template>" +
                 "<xsl:template match=\"@*\">" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;</xsl:text>" +
                  "<xsl:value-of select=\"substring-after(name(), 'ows_')\"/>" +
                  "<xsl:text disable-output-escaping=\"yes\">&gt;</xsl:text>" +
                  "<xsl:value-of select=\".\"/>" +
                  "<xsl:text disable-output-escaping=\"yes\">&lt;/</xsl:text>" +
                  "<xsl:value-of select=\"substring-after(name(), 'ows_')\"/>" +
                  "<xsl:text disable-output-escaping=\"yes\">&gt;</xsl:text>" +
                 "</xsl:template>" +
                "</xsl:stylesheet>";
    
            public static DataTable GetFullDataTable(this SPListItemCollection itemCollection)
            {
                DataSet ds = new DataSet();
    
                string xmlData = ConvertZRowToRegularXml(itemCollection.Xml);
                if (string.IsNullOrEmpty(xmlData))
                    return null;
    
                using (System.IO.StringReader sr = new System.IO.StringReader(xmlData))
                {
                    ds.ReadXml(sr, XmlReadMode.Auto);
    
                    if (ds.Tables.Count == 0)
                        return null;
    
                    return ds.Tables[0];
                }
            }
    
            static string ConvertZRowToRegularXml(string zRowData)
            {
                XslCompiledTransform transform = new XslCompiledTransform();
                XmlDocument tidyXsl = new XmlDocument();
    
                try
                {
                    //Transformer
                    tidyXsl.LoadXml(Balticovo.SharePoint.Extensions. SPListItemCollectionExtensions.xsltFromZRowToXml);
                    transform.Load(tidyXsl);
    
                    //output (result) writers
                    using (System.IO.StringWriter sw = new System.IO.StringWriter())
                    {
                        using (XmlTextWriter tw = new XmlTextWriter(sw))
                        {
                            //Source (input) readers
                            using (System.IO.StringReader srZRow = new System.IO.StringReader(zRowData))
                            {
                                using (XmlTextReader xtrZRow = new XmlTextReader(srZRow))
                                {
                                    //Transform
                                    transform.Transform(xtrZRow, null, tw);
                                    return sw.ToString();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
        }   
