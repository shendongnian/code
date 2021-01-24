      StringBuilder sr=new StringBuilder();
      for (int i=0 ;i>=mygrid.Rows.Count;i++)
      {
         sr.AppendLine(row[i].Cells["colProjection"].Value);
      }
      
      System.IO.File.WriteAllText("D:\output.txt",sr.ToString());
