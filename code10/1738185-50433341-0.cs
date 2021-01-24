      var sb = new StringBuilder();
      foreach (string item in list)
      {
         sb.Append(item + "\r\n");
      }
      richTextBox1.Text += sb.ToString();
