            Bitmap bmp = new Bitmap(MainWnd.ActiveForm.Width, MainWnd.ActiveForm.Height);
            Rectangle crec = MainWnd.ActiveForm.ClientRectangle;
            Rectangle r = this.ClientRectangle;
            MainWnd.ActiveForm.DrawToBitmap(bmp, r);
            bmp.Save("wnd.bmp");  // saves as PNG not BMP !!
 
