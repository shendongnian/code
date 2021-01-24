    void SomeMethod() {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://ebildirge.sgk.gov.tr/WPEB/amp/loginldap");
        Screenshot ss = driver.GetScreenshot();
        
        byte[] screenshotAsByteArray = ss.AsByteArray;
        Bitmap bmp;
        using (var ms = new MemoryStream(screenshotAsByteArray))
        {
            bmp = new Bitmap(ms);
        }
        Bitmap cropped = cropAtRect(bmp, new Rectangle(530, 350, 60, 40));
        cropped.Save("test.jpeg", ImageFormat.Jpeg);
    }
    static Bitmap cropAtRect(Bitmap b, Rectangle r)
    {
        Bitmap nb = new Bitmap(r.Width, r.Height);
        Graphics g = Graphics.FromImage(nb);
        g.DrawImage(b, -r.X, -r.Y);
        return nb;
    }
