    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        'here, we will custom paint the HostedControlToBeRotated instance...
        'twist rendering mode 90 counter clockwise, and shift rendering over to right-most end 
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TranslateTransform(Me.Width - Me.HostedControlToBeRotated.Height, Me.Height)
        e.Graphics.RotateTransform(-90)
        MyCompany.Forms.CustomGDI.DrawControlAndChildren(Me.HostedControlToBeRotated, e.Graphics)
        e.Graphics.ResetTransform()
        e.Graphics.Dispose()
        GC.Collect()
    End Sub
