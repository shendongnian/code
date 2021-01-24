      public class FileDropResults
      {
          public object Content { get; set; }
          public string Result { get; set; }
          public string DataFormat { get; set; }
      }
      List<FileDropResults> DD_Results;
      private void TextBox1_DragEnter(object sender, DragEventArgs e)
      {
          e.Effect = DragDropEffects.Copy;
      }
      private void TextBox1_DragDrop(object sender, DragEventArgs e)
      {
          DD_Results = new List<FileDropResults>();
          List<string> _formats = e.Data.GetFormats(false).ToList<string>();
          foreach (string _format in _formats)
          {
              DD_Results.Add(new FileDropResults() { Content = e.Data.GetData(_format), DataFormat = _format });
              if (DD_Results.Last().Content != null) 
              {
                  if (DD_Results.Last().Content.GetType() == typeof(MemoryStream))
                  {
                      using (MemoryStream _memStream = new MemoryStream())
                      {
                          ((MemoryStream)DD_Results.Last().Content).CopyTo(_memStream);
                          _memStream.Position = 0;
                          DD_Results.Last().Result =  Encoding.Unicode.GetString(_memStream.ToArray());
                      }
                  }
                  else
                  {
                      if (DD_Results.Last().Content.GetType() == typeof(String))
                          DD_Results.Last().Result = DD_Results.Last().Content.ToString();
                  }
              }
          }
      }
