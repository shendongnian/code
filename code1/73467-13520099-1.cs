    static void ImageSave(string filename, ImageFormat format, Image image, SaveFileDialog saveFileDialog1)
        { 
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Enregistrer un image";
            saveFileDialog1.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                fs.Close();
            }
        }
