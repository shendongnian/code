    using (var image = new Bitmap(16, 16)) 
    using (var g = Graphics.FromImage(image)) {
        g.DrawString(...);
        myForm.Icon = Icon.FromHandle(image.GetHicon());
    }
