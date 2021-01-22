Imports System
Imports System.Drawing
Imports System.Windows.Forms
Module modSnap
    Public Const strApplicationTitle As String = "Snap Demo"
    Public frmSnap As SnapForm
    Public ptSnap, ptStart, ptEnd As Point
    Public Class SnapForm
        Inherits Form
        Public Sub New()
            Me.Text = "Snap Demo"
            Me.ClientSize = New Size(800, 600)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.DoubleBuffered = True
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.Clear(Color.Black)
            For row As Integer = 20 To 780 Step 20
                For col As Integer = 20 To 580 Step 20
                    e.Graphics.DrawEllipse(Pens.Blue, New Rectangle(row - 2, col - 2, 4, 4))
                Next
            Next
            e.Graphics.DrawLine(Pens.Red, ptStart, ptEnd)
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim x As Integer = CInt(e.X / 20) * 20
            Dim y As Integer = CInt(e.Y / 20) * 20
            ptStart = New Point(x, y)
            ptSnap = New Point(x, y)
            Windows.Forms.Cursor.Position = Me.PointToScreen(ptSnap)
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim x As Integer = CInt(e.X / 20) * 20
                Dim y As Integer = CInt(e.Y / 20) * 20
                ' must be some delta away from original snap point
                If (x &lt ptSnap.X - 15 Or x &gt ptSnap.X + 15) Or (y &lt ptSnap.Y - 15 Or y &gt ptSnap.Y + 15) Then
                    ptSnap = New Point(x, y)
                    ptEnd = New Point(x, y)
                    Me.Invalidate(False)
                    Windows.Forms.Cursor.Position = Me.PointToScreen(ptSnap)
                End If
            End If
        End Sub
    End Class
    Public Sub main()
        Try
            frmSnap = New SnapForm
            Application.Run(frmSnap)
        Catch ex As Exception
            MessageBox.Show(ex.Message, strApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmSnap.Dispose()
        End Try
    End Sub
End Module
