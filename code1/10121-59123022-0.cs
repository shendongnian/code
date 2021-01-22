    Public Class Form1
    
        Private animatedimage As New Bitmap("C:\MyData\Search.gif")
        Private currentlyanimating As Boolean = False
    
        Private Sub OnFrameChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    
            Me.Invalidate()
    
        End Sub
    
        Private Sub AnimateImage()
    
            If currentlyanimating = True Then
                ImageAnimator.Animate(animatedimage, AddressOf Me.OnFrameChanged)
                currentlyanimating = False
            End If
    
        End Sub
    
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    
            AnimateImage()
            ImageAnimator.UpdateFrames(animatedimage)
            e.Graphics.DrawImage(animatedimage, New Point((Me.Width / 4) + 40, (Me.Height / 4) + 40))
    
        End Sub
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
            BtnStop.Enabled = False
    
        End Sub
    
        Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop.Click
    
            currentlyanimating = False
            ImageAnimator.StopAnimate(animatedimage, AddressOf Me.OnFrameChanged)
            BtnStart.Enabled = True
            BtnStop.Enabled = False
    
        End Sub
    
        Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
    
            currentlyanimating = True
            AnimateImage()
            BtnStart.Enabled = False
            BtnStop.Enabled = True
    
        End Sub
    
    End Class
