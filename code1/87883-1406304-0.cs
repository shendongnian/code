            if (Clipboard.GetImage() != null) //Excel 2007
            {
                pictureBox1.Width = Clipboard.GetImage().Width;
                pictureBox1.Height = Clipboard.GetImage().Height;
                pictureBox1.Image = Clipboard.GetImage();
                //...
            }
            else if(Clipboard.GetDataObject().GetDataPresent("PNG")) //Excel 2003
            {
                Clipboard.GetDataObject().GetFormats()
                IDataObject data = Clipboard.GetDataObject();
                MemoryStream ms = (MemoryStream)data.GetData("PNG");
                pictureBox1.Width = Image.FromStream(ms).Width;
                pictureBox1.Height = Image.FromStream(ms).Height;
                pictureBox1.Image = Image.FromStream(ms);
                //...
            }
