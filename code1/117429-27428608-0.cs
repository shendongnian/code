    <Extension()>
    Public Function GetLocalVisible(ctl As Control) As Boolean
        Dim flags As Object = GetType(Control).GetField("flags", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(ctl)
        Dim infos As PropertyInfo() = flags.GetType().GetProperties(BindingFlags.Instance Or BindingFlags.NonPublic)
        For Each info As PropertyInfo In infos
            If info.Name = "Item" AndAlso info.PropertyType.Name = "Boolean" Then
                Return (Not CBool(info.GetValue(flags, New Object() {&H10})))
            End If
        Next
        Return ctl.Visible
    End Function
