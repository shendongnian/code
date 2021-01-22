    Dim scope As New Management.ManagementScope("\\" & server & "\root\MicrosoftIISv2")
    scope.Connect()
    Dim query As New Management.ObjectQuery("select * from IISWebVirtualDirSetting")
    Dim searcher As New Management.ManagementObjectSearcher(scope, query)
    For Each obj As Management.ManagementObject In searcher.Get()
        DoSomethingWith(obj)
    Next
