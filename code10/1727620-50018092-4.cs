    private void btn_save_Click(object sender, EventArgs e)
    {
        if (points == null) points = new List<Point>();
        XmlSerializer xs = new XmlSerializer((points).GetType());
        using (TextReader tr = new StreamReader(path))
        {
            points =  (List<Point>)xs.Deserialize(tr);
            tr.Close();
        }
    }
    private void btn_load_Click(object sender, EventArgs e)
    {
        XmlSerializer xs = new XmlSerializer((points).GetType());
        using (TextWriter tw = new StreamWriter(path))
        {
            xs.Serialize(tw, points);
            tw.Close();
        }
    }
