    Public Function MembersOfGroup(ByVal GroupName As String) As List(Of DirectoryEntry)
        Dim members As New List(Of DirectoryEntry)
        Try
            Using search As New DirectoryEntry("WinNT://./" & GroupName & ",group")
                For Each member As Object In DirectCast(search.Invoke("Members"), IEnumerable)
                    Dim memberEntry As New DirectoryEntry(member)
                    members.Add(memberEntry)
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return members
    End Function
