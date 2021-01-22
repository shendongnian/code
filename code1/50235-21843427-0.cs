        private string ParseXml(string sXml, string sNs, string sMethod, out bool br)
        {
            br = false;
            string sr = "";
            try
            {
                XDocument xd = XDocument.Parse(sXml);
                if (xd.Root != null)
                {
                    XNamespace xmlns = sNs;
                    var results = from result in xd.Descendants(xmlns + sMethod + "Response")
                                  let xElement = result.Element(xmlns + sMethod + "Result")
                                  where xElement != null
                                  select xElement.Value;
                    foreach (var item in results)
                        sr = item;
                    br = (sr.Equals("true"));
                    return sr;
                }
                return "Invalid XML " + Environment.NewLine + sXml;
            }
            catch (Exception ex)
            {
                return "Invalid XML " + Environment.NewLine + ex.Message + Environment.NewLine + sXml;
            }
        }
