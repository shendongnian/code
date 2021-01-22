    Imports System.Windows.Forms
    
    Public Class MyDisplay
        Inherits Panel
    
        Public Sub New()
            Me.DoubleBuffered = True
            ' or
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
        End Sub
    End Class
