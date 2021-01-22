    Public Class Form1
        Dim p As ProcessStartInfo
        Dim process As Process
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            p = New ProcessStartInfo("iexplore.exe")
            process = process.Start(p)
        End Sub
    
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            MsgBox(process.Id)
            If process.HasExited Then
                MsgBox("yes")
            Else
                MsgBox("no")
            End If
        End Sub
    End Class
