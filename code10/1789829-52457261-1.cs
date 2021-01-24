    DataTable dt = new DataTable();
    dt.Clear();
    dt.Columns.Add("FileName");
    dt.Columns.Add("Name");
    dt.Columns.Add("ID");
    dt.Columns.Add("Date");
    
    XML_Grid.Rows.Clear();
    lbl_Path.Text = fbd.SelectedPath;
    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.xml");
    
    XmlDocument doc = new XmlDocument();
    XmlNodeList nodes = doc.GetElementsByTagName("cfdi:Emisor");
    XmlNodeList nodes1 = doc.GetElementsByTagName("cfdi:Comprobante");
    
    foreach (string tot_file in files)
    {
        doc.Load(tot_file);
        string FileName = Path.GetFileNameWithoutExtension(tot_file);
    
        for (int i = 0; i < nodes.Count; i++)
        {
            string Name = nodes[i].Attributes["Nombre"].Value;
            string ID = nodes[i].Attributes["Rfc"].Value;
            string Date = nodes1[i].Attributes["Fecha"].Value;
    
            DataRow row = dt.NewRow();
            row["FileName"] = FileName;
            row["Name"] = Name;
            row["ID"] = ID;
            row["Date"] = Date;
            dt.Rows.Add(row);
        }
    }
    
    XML_Grid.DataSource = dt;
