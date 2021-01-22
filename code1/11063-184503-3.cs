    using(SqlCommand updateCommand = new SqlCommand()) {
      updateCommand.CommandType = CommandType.Text;
      updateCommand.Connection = conn;
      conn.Open();
      StringBuilder sb = new StringBuilder("UPDATE s SET ANSWER=a FROM dbo.STUDENTAnswers s JOIN (");
      string fmt = "SELECT {0} as q, @A{0} as a";
      for(int i=tempStart; i<tempEnd; i++) {
        sb.AppendFormat(fmt, i);
        fmt=" UNION ALL SELECT {0},@A{0}";
        updateCommand.Parameters.AddWithValue("@A"+i.ToString(), Request.Form[i.ToString()]);
      }
      sb.Append(") x ON s.QuestionNum=x.q AND StudentID=@ID");
      updateCommand.CommandText = sb.ToString();
      updateCommand.Parameters.AddWithValue("@ID", uid);
    }
