        private void timerFFTp_Tick(object sender, EventArgs e)
        {
            if (drawBitmap)
            {
                Bitmap bitmap = new Bitmap(_fftControl.Width, _fftControl.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);   
                _fftControl.DrawToBitmap(bitmap, new Rectangle(0, 0, _fftControl.Width, _fftControl.Height));
                if (!fDraw)
                {
                    bitmap.MakeTransparent();
                    Bitmap fftFormBitmap = new Bitmap(_fftForm.BackgroundImage);
                    Graphics g = Graphics.FromImage(fftFormBitmap);
                    g.DrawImage(bitmap, 0, 0);
                    _fftForm.BackgroundImage = fftFormBitmap;
                }
                else
                {
                    fDraw = false;
                    _fftForm.Width = bitmap.Width + 16;
                    _fftForm.Height = bitmap.Height + 48;
                    _fftForm.BackgroundImage = bitmap;
                }
            }
        }
