        Dim bmpGrayscale As Bitmap = Bitmap.FromFile("Grayscale.tif")
        Dim bmpMonochrome As New Bitmap(bmpGrayscale.Width, bmpgrayscale.Height, Imaging.PixelFormat.Format1bppIndexed)
        Using gfxMonochrome As Graphics = Graphics.FromImage(bmpMonochrome)
            gfxMonochrome.Clear(Color.White)
        End Using
        For y As Integer = 0 To bmpGrayscale.Height - 1
            For x As Integer = 0 To bmpGrayscale.Width - 1
                If bmpGrayscale.GetPixel(x, y) <> Color.White Then
                    bmpMonochrome.SetPixel(x, y, Color.Black)
                End If
            Next
        Next
        bmpMonochrome.Save("Monochrome.tif")
