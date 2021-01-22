    Public Class Form1
    Protected Overrides Sub OnCreateControl()
      MyBase.OnCreateControl()
      SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
      MyBase.OnPaint(e)
      With e.Graphics
         .DrawLines(SystemPens.WindowText, New Point() { _
                    New Point(60, 0), _
                    New Point(60, ClientRectangle.Bottom - 60), _
                    New Point(ClientRectangle.Right, ClientRectangle.Bottom - 60)})
         For y = 0 To 100 Step 15
            Dim wid = e.Graphics.MeasureString(y.ToString, Font).Width
            .DrawString(y.ToString, Font, SystemBrushes.WindowText, 60 - wid, CSng(ClientRectangle.Bottom - 60 - (y * (ClientRectangle.Size.Height - 60) / 100)))
         Next
         Dim sf As New System.Drawing.StringFormat(System.Drawing.StringFormatFlags.DirectionVertical)
         For x = 0 To 5
            Dim dateStr = DateTime.Today.AddDays(x).ToShortDateString()
            Dim xCoord As Integer = CInt(60 + (ClientSize.Width - 60) * (x + 0.5) / 6)
            Dim yBottom As Integer = ClientRectangle.Bottom - 60
            .DrawString(dateStr, Font, SystemBrushes.WindowText, xCoord, yBottom, sf)
            Dim yTop As Integer = CInt(yBottom - (CInt(Date.Today.AddDays(x).DayOfWeek) + 2) * (ClientSize.Height - 60) / 10)
            Dim bar As Rectangle = New Rectangle(xCoord, yTop, 18, yBottom - yTop)
            .FillRectangle(Brushes.LightBlue, bar)
            .DrawRectangle(SystemPens.WindowText, System.Drawing.Rectangle.Round(bar))
         Next
      End With
    End Sub
    End Class
