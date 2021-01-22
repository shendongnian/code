    Public Sub New()
        Me.SetStyle(ControlStyles.ResizeRedraw Or _
                    ControlStyles.DoubleBuffer Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.AllPaintingInWmPaint, _
                    True)
        Me.UpdateStyles()
    End Sub
