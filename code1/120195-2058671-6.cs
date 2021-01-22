        using (Bitmap myBitmap = new Bitmap("c:\test.bmp"))
        {
            using (Graphics gfxBitmap = Graphics.FromImage(myBitmap))
            {
                using (Graphics gfxForm = this.CreateGraphics())
                {
                    IntPtr hdcForm = gfxForm.GetHdc();
                    IntPtr hdcBitmap = gfxBitmap.GetHdc();
                    BitBlt(hdcForm, 0, 0, myBitmap.Width, myBitmap.Height, hdcBitmap, 0, 0, 0x00CC0020);
                    gfxForm.ReleaseHdc(hdcForm);
                    gfxBitmap.ReleaseHdc(hdcBitmap);
                }
            }
        }
