        Public Function foo() As Integer
        Try
            Dim searcher As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_SerialPort")
            For Each queryObj As ManagementObject In searcher.Get()
                Debug.WriteLine(queryObj("Caption"))
                Debug.WriteLine(queryObj("Description"))
                Debug.WriteLine(queryObj("DeviceID"))
                Debug.WriteLine(queryObj("Name"))
                Debug.WriteLine(queryObj("PNPDeviceID"))
            Next
        Catch err As ManagementException
            Stop
        End Try
    End Function
    Public Function bar() As Integer
        Try
            Dim searcher As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0")
            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("Caption").ToString.Contains("(COM") Then
                    Debug.WriteLine(queryObj("Caption"))
                    Debug.WriteLine(queryObj("Description"))
                    Debug.WriteLine(queryObj("DeviceID"))
                    Debug.WriteLine(queryObj("Name"))
                    Debug.WriteLine(queryObj("PNPDeviceID"))
                End If
            Next
        Catch err As ManagementException
            Stop
        End Try
    End Function
