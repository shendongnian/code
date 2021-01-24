    Dim UnderlayingImage as Image
    UnderLayingImage = New Bitmap(Me.PictureBox1.Width, Me.Picturebox1.Height)
    Dim g As Graphics = Graphics.FromImage(UnderLayingImage)
    Dim bgBrush As SolidBrush = New SolidBrush(Color.LightSlateGray)
    Dim bgBrushWhite As SolidBrush = New SolidBrush(Color.White)
    Dim shPen As Pen = New Pen(Color.Black)
    Dim rect As RectangleF = New RectangleF(50, 50, 100, 100)
    g.FillRectangle(bgBrush, rect)
    g.DrawRectangle(Pens.Black, Rectangle.Round(rect))
    Me.PictureBoxDrawing.Image = UnderLayingImage 
	
