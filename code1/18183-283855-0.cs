    Public mobNotifyIcon As NotifyIcon
    Public WithEvents mobContextMenu As ContextMenu
    Public Sub Main()
        
        mobContextMenu = New ContextMenu
        SetupMenu()
        mobNotifyIcon = New NotifyIcon()
        With mobNotifyIcon
            .Icon = My.Resources.NotifyIcon
            .ContextMenu = mobContextMenu
            .BalloonTipText = String.Concat("Monitor the EDS Transfer Service", vbCrLf, "Right click icon for menu")
            .BalloonTipIcon = ToolTipIcon.Info
            .BalloonTipTitle = "EDS Transfer Monitor"
            .Text = "EDS Transfer Service Monitor"
            AddHandler .MouseClick, AddressOf showBalloon
            .Visible = True
        End With
        Application.Run()
    End Sub
    Private Sub SetupMenu()
        With mobContextMenu
            .MenuItems.Add(New MenuItem("Configure", New EventHandler(AddressOf Config)))
            .MenuItems.Add("-")
            .MenuItems.Add(New MenuItem("Start", New EventHandler(AddressOf StartService)))
            .MenuItems.Add(New MenuItem("Stop", New EventHandler(AddressOf StopService)))
            .MenuItems.Add("-")
            .MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitController)))
        End With
        GetServiceStatus()
    End Sub
