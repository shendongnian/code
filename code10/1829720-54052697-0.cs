            if (Page.IsValid)
            {
                System.Drawing.Image image = new System.Drawing.Bitmap(fupPhoto.PostedFile.InputStream); //Bitmap.FromFile(filename);
                Graphics graphics = Graphics.FromImage(image);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                Color color = ColorTranslator.FromHtml("#D3D3D3");
                string text = "Culturely.Co";
                graphics.DrawString(text, new Font("Arail", 30, FontStyle.Bold), new SolidBrush(color), new Point(268, 245));
                //image.Save("watermarked" + filename);
                string filename = fupPhoto.FileName;
                string outputname = "Watermarked" + filename;
                image.Save("C:\\" + outputname);
