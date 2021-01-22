            XmlSerializer x = new XmlSerializer(typeof(GridState));
            XDocument doc = new XDocument();
            using (XmlWriter xw = doc.CreateWriter())
            {
                x.Serialize(xw, new GridState
                    {
                        GridName= txtGridName.Text,
                        GridColumns = GetGridColumnStates()
                    });
                xw.Close();
            }
            XElement el = doc.Root;
