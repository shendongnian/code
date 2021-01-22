    Imports System.Drawing
    Imports System.Drawing.Imaging
    Imports System
    
    Public Class Form1
    
        Dim MarkerBox1 As New PictureBox
        Dim MarkerBox2 As New PictureBox
        Dim MarkerBox3 As New PictureBox
    
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            PictureBox1.Image = New Bitmap("C:\BackGround.bmp")
    
            MarkerBox1.Image = New Bitmap("C:\TestOverlay1.png")
            MarkerBox1.BackColor = System.Drawing.Color.Transparent
            MarkerBox1.Visible = True
            MarkerBox1.SizeMode = PictureBoxSizeMode.AutoSize
            PictureBox1.Controls.Add(MarkerBox1)
    
            MarkerBox2.Image = New Bitmap("C:\TestOverlay2.png")
            MarkerBox2.BackColor = System.Drawing.Color.Transparent
            MarkerBox2.Visible = True
            MarkerBox2.SizeMode = PictureBoxSizeMode.AutoSize
            MarkerBox1.Controls.Add(MarkerBox2)
    
            MarkerBox3.Image = New Bitmap("C:\TestOverlay3.png")
            MarkerBox3.BackColor = System.Drawing.Color.Transparent
            MarkerBox3.Visible = True
            MarkerBox3.SizeMode = PictureBoxSizeMode.AutoSize
            MarkerBox2.Controls.Add(MarkerBox3)
     
    
        End Sub
    
        Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
            If CheckBox1.Checked Then
                MarkerBox1.Visible = True
            Else
                MarkerBox1.Visible = False
            End If
            Visibilitychanged()
        End Sub
    
        Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
            If CheckBox2.Checked Then
                MarkerBox2.Visible = True
            Else
                MarkerBox2.Visible = False
            End If
            Visibilitychanged()
        End Sub
    
        Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
            If CheckBox3.Checked Then
                MarkerBox3.Visible = True
            Else
                MarkerBox3.Visible = False
            End If
            Visibilitychanged()
        End Sub
    
        Private Sub Visibilitychanged()
    
            PictureBox1.Controls.Clear()
            MarkerBox1.Controls.Clear()
            MarkerBox2.Controls.Clear()
            MarkerBox3.Controls.Clear()
    
            Dim PB As PictureBox = PictureBox1
            If MarkerBox1.Visible Then
                PB.Controls.Add(MarkerBox1)
                PB = MarkerBox1
            End If
            If MarkerBox2.Visible Then
                PB.Controls.Add(MarkerBox2)
                PB = MarkerBox2
            End If
            If MarkerBox3.Visible Then
                PB.Controls.Add(MarkerBox3)
                PB = MarkerBox3
            End If
      
        End Sub
