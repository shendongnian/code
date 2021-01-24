            var txt = "Content from Eikon: <span class=\"tr-pnac\" id=\"x2\">ID:nHKS8cG006</span>";
            var xml = new System.Xml.XmlDocument();
            xml.LoadXml($"<root>{txt}</root>");
            var spanNodes = xml.DocumentElement.SelectNodes("//span[contains(@class, 'tr-pnac')]");
            //or
            //var spanNodes = xml.DocumentElement.SelectNodes("//span[@class='tr-pnac']");
            foreach (XmlNode n in spanNodes)
            {
                System.Diagnostics.Debug.WriteLine(n.InnerText.Substring(3));
            }
