    Private Sub Control_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) _
    Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.FillRectangle(Brushes.Aqua, New Rectangle(10, 10, 10, 90))
        g.FillPolygon(Brushes.Aqua, New Point() { _
            New Point(10, 10), _
            New Point(20, 10), _
            New Point(40, 50), _
            New Point(30, 50)})
        g.FillPolygon(Brushes.Aqua, New Point() { _
            New Point(10, 100), _
            New Point(20, 100), _
            New Point(40, 50), _
            New Point(30, 50)})
        g.DrawLine(Pens.Black, New Point(10, 10), New Point(10, 100))
        g.DrawLine(Pens.Black, New Point(10, 100), New Point(20, 100))
        g.DrawLine(Pens.Black, New Point(20, 100), New Point(40, 50))
        g.DrawLine(Pens.Black, New Point(40, 50), New Point(20, 10))
        g.DrawLine(Pens.Black, New Point(20, 10), New Point(10, 10))
...
