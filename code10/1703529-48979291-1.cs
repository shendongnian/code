    public class FileDropResults
    {
        public object Content { get; set; }
        public string Result { get; set; }
        public string DataFormat { get; set; }
        public List<Bitmap> Images { get; set; }
        public List<string> HttpSourceImages { get; set; }
    }
    public List<FileDropResults> DD_Results;
    private void TextBox1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
    private void TextBox3_DragDrop(object sender, DragEventArgs e)
    {
        DD_Results = new List<FileDropResults>();
        List<string> _formats = e.Data.GetFormats(false).ToList<string>();
        foreach (string _format in _formats)
        {
            switch (_format)
            {
                case ("FileGroupDescriptor"):
                case ("FileGroupDescriptorW"):
                case ("DragContext"):
                case ("UntrustedDragDrop"):
                    break;
                case ("DragImageBits"):
                    DD_Results.Add(new FileDropResults() { Content = (MemoryStream)e.Data.GetData(_format, true), DataFormat = _format });
                    break;
                case ("FileDrop"):
                    DD_Results.Add(new FileDropResults() { Content = null, DataFormat = "ImageList" });
                    DD_Results.Last().Images = new List<Bitmap>();
                    DD_Results.Last().Images.AddRange(
                        ((string[])e.Data.GetData(DataFormats.FileDrop, true))
                        .ToList()
                        .Select(img => Bitmap.FromFile(img))
                        .Cast<Bitmap>().ToArray());
                    break;
                case ("HTML Format"):
                    DD_Results.Add(new FileDropResults() { Content = e.Data.GetData(DataFormats.Html, true), DataFormat = _format });
                    DD_Results.Last().HttpSourceImages = DD_GetHtmlImages(DD_Results.Last().Content.ToString());
                    break;
                default:
                    DD_Results.Add(new FileDropResults() { Content = e.Data.GetData(_format, true), DataFormat = _format });
                    break;
            }
            if (DD_Results.Count > 0 && DD_Results.Last().Content != null && DD_Results.Last().Result == null) 
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
    public List<string> DD_GetHtmlImages(string HtmlSource)
    {
        MatchCollection matches = Regex.Matches(HtmlSource, @"<img[^>]+src=""([^""]*)""", 
                                  RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        return (matches.Count> 0) ? matches.Cast<Match>().Select(x => x.Groups[1].ToString()).ToList() : null;
    }
