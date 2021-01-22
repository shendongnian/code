    <System.ComponentModel.DesignerCategory("")> _
    Public Class AutoScaleButton
      Inherits Button
      Private _AutoScaleImage As Image
      Public Property AutoScaleImage() As Image
        Get
          Return _AutoScaleImage
        End Get
        Set(value As Image)
          _AutoScaleImage = value
          If value IsNot Nothing Then Me.Invalidate()
        End Set
      End Property
      Private _AutoScaleBorder As Integer
      Public Property AutoScaleBorder() As Integer
        Get
          Return _AutoScaleBorder
        End Get
        Set(ByVal value As Integer)
          _AutoScaleBorder = value
          Me.Invalidate()
        End Set
      End Property
      Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        DrawResizeImage(e.Graphics)
      End Sub
      Private Sub DrawResizeImage(ByRef g As Graphics)
        If _AutoScaleImage Is Nothing Then Exit Sub
        Dim iB As Integer = AutoScaleBorder, iOff As Integer = 0
        Dim rectLoc As Rectangle, rectSrc As Rectangle
        Dim sizeDst As Size = New Size(Math.Max(0, Me.Width - 2 * iB), Math.Max(0, Me.Height - 2 * iB))
        Dim sizeSrc As Size = New Size(_AutoScaleImage.Width, _AutoScaleImage.Height)
        Dim ratioDst As Double = sizeDst.Height / sizeDst.Width
        Dim ratioSrc As Double = sizeSrc.Height / sizeSrc.Width
        rectSrc = New Rectangle(0, 0, sizeSrc.Width, sizeSrc.Height)
        If ratioDst < ratioSrc Then
          iOff = (sizeDst.Width - (sizeDst.Height * sizeSrc.Width / sizeSrc.Height)) / 2
          rectLoc = New Rectangle(iB + iOff, iB, _
                                  sizeDst.Height * sizeSrc.Width / sizeSrc.Height, _
                                  sizeDst.Height)
        Else
          iOff = (sizeDst.Height - (sizeDst.Width * sizeSrc.Height / sizeSrc.Width)) / 2
          rectLoc = New Rectangle(iB, iB + iOff, _
                                  sizeDst.Width, _
                                  sizeDst.Width * sizeSrc.Height / sizeSrc.Width)
        End If
        g.DrawImage(_AutoScaleImage, rectLoc, rectSrc, GraphicsUnit.Pixel)
      End Sub
    End Class
