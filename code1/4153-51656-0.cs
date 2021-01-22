    Me.lstDrives.Items.Clear()
    For Each item As DriveInfo In My.Computer.FileSystem.Drives
        If item.DriveType = DriveType.Removable Or item.DriveType = DriveType.CDRom Then
            Me.lstDrives.Items.Add(item.Name)
        End If
    Next
