    Public Sub highlightImage()
        Dim l As Single() = {2, 2, 2, 2}
        Dim p As New Pen(Color.Gray, 1)
        p.DashPattern = l
        Dim g As Graphics = picColor.CreateGraphics()
        g.DrawRectangle(p, 0, 0, picColor.Width - 1, picColor.Height - 1)
    End Sub
