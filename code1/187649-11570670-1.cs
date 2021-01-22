    Imports System
    Imports System.Drawing
    Imports System.Windows.Forms
    
    Public Class SelectablePanel
        Inherits Panel
    
        Public Sub SelectablePanel()
            Me.SetStyle(ControlStyles.Selectable, True)
            Me.TabStop = True
        End Sub
        
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            Me.Focus()
            MyBase.OnMouseDown(e)
        End Sub
    
        Protected Overrides Function IsInputKey(ByVal keydata As Keys) As Boolean
            If (keydata = Keys.Up OrElse keydata = Keys.Down) Then Return True
            If (keydata = Keys.Left OrElse keydata = Keys.Right) Then Return True
            Return MyBase.IsInputKey(keydata)
        End Function
    
        Protected Overrides Sub OnEnter(ByVal e As EventArgs)
            Me.Invalidate()
            MyBase.OnEnter(e)
        End Sub
    
        Protected Overrides Sub OnLeave(ByVal e As EventArgs)
            Me.Invalidate()
            MyBase.OnLeave(e)
        End Sub
    
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            MyBase.OnPaint(pe)
            If (Me.Focused) Then
                Dim rc As Rectangle = Me.ClientRectangle
                rc.Inflate(-2, -2)
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc)
            End If
        End Sub
    
    End Class
