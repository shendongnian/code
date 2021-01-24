    private void PrintPage(object o, PrintPageEventArgs e)
        {
            Image img = Image.FromFile(@"C:\Users\pavel\OneDrive - OSZ IMT\Desktop\MonaLisa.jpg");
            Image resizedImage = ResizeImage(img, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height);
            e.Graphics.DrawImage(resizedImage, 0, 0);
        }
