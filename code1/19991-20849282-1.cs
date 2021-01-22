    Imports System.Windows.Forms.Design
    Imports System.Reflection
        Public Class TransparentControl : Inherits Control
            Protected Overrides ReadOnly Property CreateParams As CreateParams
                Get
                    Dim cp As CreateParams = MyBase.CreateParams()
                    cp.ExStyle = cp.ExStyle Or 32 'WS_EX_TRANSPARENT
                    Return cp
                End Get
            End Property
            Protected Sub InvalidateEx(rct As Rectangle)
                Me.Invalidate(rct)
                If IsNothing(Parent) Then Exit Sub
                Parent.Invalidate(New Rectangle(Me.Location, rct.Size), True)
            End Sub
            Protected Sub InvalidateEx()
                Me.Invalidate()
                If IsNothing(Parent) Then Exit Sub
                Parent.Invalidate(New Rectangle(Me.Location, Me.Size), True)
            End Sub
            Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
                'MyBase.OnPaintBackground(pevent)
            End Sub
    
            Protected Overrides Sub OnPaint(e As PaintEventArgs)
                MyBase.OnPaint(e)
                ' draw the layout on e.Graphics
            End Sub
        End Class
