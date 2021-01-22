        public BitmapImage QuestionIcon
        {
            get
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    System.Drawing.Bitmap dImg = SystemIcons.ToBitmap();
                    dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
                    bImg.BeginInit();
                    bImg.StreamSource = new MemoryStream(ms.ToArray());
                    bImg.EndInit();
                    return bImg;
                }
            }
        }
