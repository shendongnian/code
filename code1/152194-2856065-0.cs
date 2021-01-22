    Public Class PrintScreen
        '   Code that explicity finds the outter rectangle size of the current form and then 
        '   takes a screen print of that image.
        Shared Sub CurrentForm(ByRef myForm As Windows.Forms.Form)
            Dim memoryImage As Bitmap
            Dim myGraphics As Graphics = myForm.CreateGraphics()
            Dim s As Size = myForm.Size
            memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
            Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
            memoryGraphics.CopyFromScreen(myForm.Location.X, myForm.Location.Y, 0, 0, s)
            memoryGraphics.DrawImage(memoryImage, 0, 0)
            SaveImage(memoryImage, myForm)
        End Sub
        '   Method to save the screen to a file in the \My Pictures\AppName\ folder
        Private Shared Sub SaveImage(ByVal b As Bitmap, ByVal form As Windows.Forms.Form)
            Dim AppPictureFolder As String
            Dim fileName As String
            '   Create a file with the forms title + datetime stamp.
            fileName = String.Format("{0} {1}.png", form.Text, Date.Now.ToString("yyyyMMdd HHmmss"))
            AppPictureFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), [Assembly].GetExecutingAssembly.GetName.Name)
            If Not System.IO.Directory.Exists(AppPictureFolder) Then
                System.IO.Directory.CreateDirectory(AppPictureFolder)
            End If
            b.Save(System.IO.Path.Combine(AppPictureFolder, fileName))
            System.Diagnostics.Process.Start(System.IO.Path.Combine(AppPictureFolder, fileName))
        End Sub
    End Class
 
