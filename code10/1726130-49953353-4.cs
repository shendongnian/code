    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using (FileStream stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
    using (StreamReader reader = new StreamReader(stream, Encoding.Default))
        TextInput = reader.ReadToEnd();
    Font font = new Font("Lucida Console", 4, FontStyle.Regular, GraphicsUnit.Point);
    using (Bitmap bitmap = ASCIIArtBitmap(TextInput, font))
        bitmap.Save(@"[FilePath1]", ImageFormat.Png);
    using (Bitmap bitmap = ASCIIArtBitmapGdiPlus(TextInput, font))
        bitmap.Save(@"[FilePath2]", ImageFormat.Png);
    using (Bitmap bitmap = ASCIIArtBitmapGdiPlusPath(TextInput, font))
        bitmap.Save(@"[FilePath3]", ImageFormat.Png);
    font.Dispose();
