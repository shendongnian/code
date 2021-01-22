    string str = "<ROOT>AQID</ROOT>";
    XmlTextReader r = new XmlTextReader(new StringReader(str));
    try
    {
      while (r.Read())
      {
      }
    }
    finally
    {
      r.Close();
    }
