    Public swApp As SldWorks.SldWorks
    Function GetSolidWorks(ForceLaunch As Boolean) As Boolean
        If Not swApp Is Nothing Then
            SetSolidWorksVisibility()
            Return True
        Else
            Try
                swApp = GetObject(, "SldWorks.Application")
                If swApp Is Nothing Then Return False
    
                SetSolidWorksVisibility()
                Return True
            Catch ex As Exception
                If Not ForceLaunch Then Return False
    
                swApp = CreateObject("SldWorks.Application")
                If swApp Is Nothing Then Return False
    
                SetSolidWorksVisibility()
    
                'simple timer to wait for solidworks to repond
                System.Threading.Thread.Sleep(5000)
    
                Return True
            End Try
        End If
    End Function
    Private Sub SetSolidWorksVisibility()
        If Not swApp.Visible Then swApp.Visible = True
        If Not swApp.FrameState = SwConst.swWindowState_e.swWindowMaximized Then swApp.FrameState = SwConst.swWindowState_e.swWindowMaximized
    End Sub
