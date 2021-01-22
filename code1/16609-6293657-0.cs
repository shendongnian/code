        Panel1.Dock = DockStyle.None // If Panel Dockstyle is in Fill mode
        Panel1.Width = 5000  // Original Size without scrollbar
        Panel1.Height = 5000 // Original Size without scrollbar
        Dim bmp As New Bitmap(Me.Panel1.Width, Me.Panel1.Height)
        Me.Panel1.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Panel1.Width, Me.Panel1.Height))
        'Me.Panel1.DrawToBitmap(bmp, Panel1.ClientRectangle)
        bmp.Save("C:\panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        Panel1.Dock = DockStyle.Fill
