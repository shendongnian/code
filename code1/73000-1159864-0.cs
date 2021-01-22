    using System;
    using System.IO;
    using System.Drawing;
    using System.Windows.Forms;
    using QuickPDFAX0714;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private string LicenseKey = " your key here ";
            private string OriginalFileName = "D:\\QuickPDFLibrary\\hello1.pdf";
            private string NewFileName = "D:\\QuickPDFLibrary\\hello2.pdf";
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                ShowPDF(OriginalFileName);
            }
            private void ShowPDF(string fileName)
            {
                PDFLibrary qp = new PDFLibrary();
                qp.UnlockKey(LicenseKey);
                qp.LoadFromFile(fileName);
                // Fit width of PDF to width of picture box
                int dpi = Convert.ToInt32((pictureBox1.Width * 72) / qp.PageWidth());
                byte[] bmpData = (byte[])qp.RenderPageToVariant(dpi, 1, 0);
                MemoryStream ms = new MemoryStream(bmpData);
                Bitmap bmp = new Bitmap(ms);
                pictureBox1.Image = bmp;
                ms.Dispose();
            }
            private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
            {
                PDFLibrary qp = new PDFLibrary();
                qp.UnlockKey(LicenseKey);
                qp.LoadFromFile(OriginalFileName);
                // Calculate co-ordinates, width of PDF fitted to width of PictureBox
                double xpos = ((double)e.X / (double)pictureBox1.Width) * qp.PageWidth();
                double ypos = qp.PageHeight() - ((double)e.Y / (double)pictureBox1.Width) * qp.PageWidth();
                qp.SetTextSize(24);
                qp.SetTextColor(1, 0, 0);
                qp.DrawText(xpos, ypos, "A");
                qp.SaveToFile(NewFileName);
                ShowPDF(NewFileName);
            }
        }
    }
