    Dim img As Image = Image.FromFile("c:\jpg\1.jpg")
    Dim g As Graphics
    
    pic1.Image = New Bitmap(180, 180, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    g = Graphics.FromImage(pic1.Image)
    g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
    g.DrawImage(img, 0, 0, pic1.Image.Width, pic1.Image.Height)
