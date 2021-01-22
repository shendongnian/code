private void LoadGrbs()
        {
            WebClient grbXmlFile = new WebClient();
            // Make sure the crossdomainpolicy.xml file exists on the remote server.
            grbXmlFile.DownloadStringAsync(new Uri("url_xml_generating_php_file", UriKind.Absolute));
            grbXmlFile.DownloadStringCompleted += new DownloadStringCompletedEventHandler(grbsXmlLoaded);
        }
        private void grbsXmlLoaded(object sender, DownloadStringCompletedEventArgs e)
        {
            processGrbXml(e.Result);
        }
        private void processGrbXml(string grbData)
        {
            XDocument grbs = XDocument.Parse(grbData);
            var query = from g in grbs.Descendants("grb")
                        select new
                            {
                                grbId = (string)g.Element("grb_id"),
                                grbDec = (string)g.Element("burst_dec")
                            };
            foreach (var grb in query)
            {
                grbListbox.Items.Add(grb.grbId);
            }
            
        }
