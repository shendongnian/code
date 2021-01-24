    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    private FileDropResults DD_Results;
    public class FileDropResults
    {
        public enum DataFormat : int
        {
            MemoryStream = 0,
            Text,
            UnicodeText,
            Html,
            Bitmap,
            ImageBits,
        }
        public FileDropResults() { this.Contents = new List<DropContent>(); }
        public List<DropContent> Contents { get; set; }
        public class DropContent
        {
            public object Content { get; set; }
            public string Result { get; set; }
            public DataFormat Format { get; set; }
            public string DataFormatName { get; set; }
            public List<Bitmap> Images { get; set; }
            public List<string> HttpSourceImages { get; set; }
        }
    }
    private void TextBox1_DragDrop(object sender, DragEventArgs e)
    {
        GetDataFormats(e.Data);
    }
    private void TextBox1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
    private void GetDataFormats(IDataObject Data)
    {
        DD_Results = new FileDropResults();
        List<string> _formats = Data.GetFormats(false).ToList<string>();
        foreach (string _format in _formats)
        {
            FileDropResults.DropContent CurrentContents = new FileDropResults.DropContent() 
            { DataFormatName = _format };
            switch (_format)
            {
                case ("FileGroupDescriptor"):
                case ("FileGroupDescriptorW"):
                case ("DragContext"):
                case ("UntrustedDragDrop"):
                    break;
                case ("DragImageBits"):
                    CurrentContents.Content = (MemoryStream)Data.GetData(_format, true);
                    CurrentContents.Format = FileDropResults.DataFormat.ImageBits;
                    break;
                case ("FileDrop"):
                    CurrentContents.Content = null;
                    CurrentContents.Format = FileDropResults.DataFormat.Bitmap;
                    CurrentContents.Images = new List<Bitmap>();
                    CurrentContents.Images.AddRange(
                        ((string[])Data.GetData(DataFormats.FileDrop, true))
                        .ToList()
                        .Select(img => Bitmap.FromFile(img))
                        .Cast<Bitmap>().ToArray());
                    break;
                case ("HTML Format"):
                    CurrentContents.Format = FileDropResults.DataFormat.Html;
                    CurrentContents.Content = Data.GetData(DataFormats.Html, true);
                    int HtmlContentInit = CurrentContents.Content.ToString().IndexOf("<html>", StringComparison.InvariantCultureIgnoreCase);
                    if (HtmlContentInit > 0)
                        CurrentContents.Content = CurrentContents.Content.ToString().Substring(HtmlContentInit);
                    CurrentContents.HttpSourceImages = DD_GetHtmlImages(CurrentContents.Content.ToString());
                    break;
                case ("UnicodeText"):
                    CurrentContents.Format = FileDropResults.DataFormat.UnicodeText;
                    CurrentContents.Content = Data.GetData(DataFormats.UnicodeText, true);
                    break;
                case ("Text"):
                    CurrentContents.Format = FileDropResults.DataFormat.Text;
                    CurrentContents.Content = Data.GetData(DataFormats.Text, true);
                    break;
                default:
                    CurrentContents.Format = FileDropResults.DataFormat.MemoryStream;
                    CurrentContents.Content = Data.GetData(_format, true);
                    break;
            }
            if (CurrentContents.Content != null)
            {
                if (CurrentContents.Content.GetType() == typeof(MemoryStream))
                {
                    using (MemoryStream _memStream = new MemoryStream())
                    {
                        ((MemoryStream)CurrentContents.Content).CopyTo(_memStream);
                        _memStream.Position = 0;
                        CurrentContents.Result = Encoding.Unicode.GetString(_memStream.ToArray());
                    }
                }
                else
                {
                    if (CurrentContents.Content.GetType() == typeof(String))
                        CurrentContents.Result = CurrentContents.Content.ToString();
                }
            }
            DD_Results.Contents.Add(CurrentContents);
        }
    }
    public List<string> DD_GetHtmlImages(string HtmlSource)
    {
        MatchCollection matches = Regex.Matches(HtmlSource, @"<img[^>]+src=""([^""]*)""",
                                  RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        return (matches.Count > 0)
                ? matches.Cast<Match>()
                        .Select(x => x.Groups[1]
                        .ToString()).ToList()
                : null;
    }
