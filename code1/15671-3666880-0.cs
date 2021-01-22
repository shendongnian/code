    Public Sub RemoveBreakOnAnyMember()
        Dim debugger As EnvDTE.Debugger = DTE.Debugger
        Dim bps As Breakpoints
        bps = debugger.Breakpoints
        If (bps.Count > 0) Then
            Dim bp As Breakpoint
            For Each bp In bps
                Dim split As String() = bp.File.Split(New [Char]() {"\"c})
                If (split.Length > 0) Then
                    Dim strName = split(split.Length - 1)
                    If (strName.Equals(DTE.ActiveDocument.Name)) Then
                        bp.Delete()
                    End If
                End If
            Next
        End If
    End Sub
