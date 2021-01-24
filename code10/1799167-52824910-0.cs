    var sb = new StringBuilder();
              foreach (var item in results)
                {
                    sb.Append(item);
                    sb.Append " ";
                }
    
                    richTextBox1.Text = sb.ToString();
