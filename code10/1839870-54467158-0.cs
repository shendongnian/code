       var xmlDoc = new XmlDocument();
        xmlDoc.Load(FName);
        DataTable DTConfig = new DataTable();
        DTConfig.Columns.Add("Key", typeof(string));
        DTConfig.Columns.Add("Value", typeof(string));
        DTConfig.Columns.Add("OldValue", typeof(string));
        try
        {
            foreach (XmlElement xmlElement in xmlDoc.SelectNodes("configuration/appSettings"))
            {
                foreach (XmlNode node in xmlElement)
                {
                    if (node.Attributes != null && node.Attributes.Count > 1)
                    {
                        string MyKey = "";
                        string MyVal = "";
                        if (node.Attributes[0].Value != null)
                        {
                            MyKey = node.Attributes[0].Value;
                        }
                        if (node.Attributes[1].Value != null)
                        {
                            MyVal = node.Attributes[1].Value;
                        }
                        DataRow DR = DTConfig.NewRow();
                        DR["Key"] = MyKey;
                        DR["Value"] = MyVal;
                        DR["OldValue"] = MyVal;
                        if (MyKey != "")
                        {
                            DTConfig.Rows.Add(DR);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
        TxtFname.Text = FName;
        DGConfig.DataSource = DTConfig;
        return true;
