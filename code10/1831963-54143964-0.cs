      public void xmlSort()
        {
            XElement root = XElement.Load("D:\\score.xml");
            XElement[] sortedTables = root.Elements("xmlScore").OrderByDescending(t => (int)t.Element("score")).ToArray();
            root.ReplaceAll(sortedTables);
            root.Save("D:\\score.xml");
        }
     public void readXml()
        {
            FileStream fs = new FileStream("D:\\score.xml", FileMode.Open, FileAccess.Read);
            ls = (List<xmlScore>)xs.Deserialize(fs);
            dataGridView1.DataSource = ls;
            fs.Close();
        }
