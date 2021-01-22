            OpenFD.FileName = "";
            OpenFD.Title = "open image";
            OpenFD.InitialDirectory = "C";
            OpenFD.Filter = "JPEG|*.jpg|Bmp|*.bmp|All Files|*.*.*";
            if (OpenFD.ShowDialog() == DialogResult.OK)
            {
                file = OpenFD.FileName;
                
                bac = Image.FromFile(file);
                pictureBox1.Image = bac;
                pictureBox1.Invalidate();
                
            }
        }
