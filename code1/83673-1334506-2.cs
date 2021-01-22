      var qry = from dispObj in elemList
                group dispObj by dispObj.ElementName;
      StringBuilder sb = new StringBuilder();
      foreach (var grp in qry)
      {
        int count = grp.Count();
        sb.AppendLine(string.Format("{0}({1})", grp.Key,grp.Count()));
      }
      textBox1.Text = sb.ToString();
