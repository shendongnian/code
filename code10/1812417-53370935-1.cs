      StringBuilder sr=new StringBuilder();
      for (int i=0 ;i>=mygrid.Rows.Count;i++)
      {
         sr.AppendLine(mygrid.Rows[i].Cells["colProjection"].Text);
      }
      
      System.IO.File.WriteAllText("D:\output.txt",sr.ToString());
