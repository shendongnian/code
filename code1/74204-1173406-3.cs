    Using bmpGrayscale As Bitmap = Bitmap.FromFile("Grayscale.tif")
        Using bmpMonochrome As New Bitmap(bmpGrayscale.Width, bmpgrayscale.Height, Imaging.PixelFormat.Format1bppIndexed)
            Using gfxMonochrome As Graphics = Graphics.FromImage(bmpMonochrome)
                gfxMonochrome.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                gfxMonochrome.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                gfxMonochrome.DrawImage(bmpGrayscale, new Rectangle(0, 0, bmpMonochrome.Width, bmpMonochrome.Height)
            End Using
            bmpMonochrome.Save("Monochrome.tif")
        End Using
    End Using
