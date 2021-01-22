    Using gr As Graphics = Graphics.FromImage(SourceImage) 'SourceImage is a Bitmap object'
      Dim gray_matrix As Single()() = {
        New Single() {0.299F, 0.299F, 0.299F, 0, 0},
        New Single() {0.587F, 0.587F, 0.587F, 0, 0},
        New Single() {0.114F, 0.114F, 0.114F, 0, 0},
        New Single() {0, 0, 0, 1, 0},
        New Single() {0, 0, 0, 0, 1}
      }
      Dim ia As New System.Drawing.Imaging.ImageAttributes
      ia.SetColorMatrix(New System.Drawing.Imaging.ColorMatrix(gray_matrix))
      ia.SetThreshold(0.8)
      Dim rc As New Rectangle(0, 0, SourceImage.Width, SourceImage.Height)
      gr.DrawImage(SourceImage, rc, 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel, ia)
    End Using
