    System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Parse(s);
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    System.IO.StringWriter sr = new System.IO.StringWriter(sb);
    doc.Save(sr);
    string ss = sb.ToString();//result
    sr.Close();
