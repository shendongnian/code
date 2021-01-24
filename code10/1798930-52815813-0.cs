    using System.Windows.Forms;
    public static string RtfFileAsPlainText(string rtfPathName)
    {
        using (var rtf = new RichTextBox())
        {
            rtf.Rtf = File.ReadAllText(rtfPathName);
            return rtf.Text;
        }
    }
