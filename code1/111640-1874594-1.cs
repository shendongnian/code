    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\Settings.Config") Then
            FileOpen(1, System.IO.Directory.GetCurrentDirectory() + "\Settings.Config", OpenMode.Random, OpenAccess.ReadWrite)
            FileGet(1, SettingVar1, 1)
            FileGet(1, SettingVar2, 2)
            FileGet(1, SettingVar3, 3)
            'etc
            FileClose(1)
        Else
            FileOpen(1, System.IO.Directory.GetCurrentDirectory() + "\Settings.Config", Openmode.Random, OpenAccess.ReadWrite)
            FilePut(1, "Static Setting to write", 1) 'insert a string
            FilePut(1, 3, 2) 'insert a number
            FilePut(1, New DBMC, 3) 'Any object
            'etc...
            FileClose(1)
        End If
    End Sub
