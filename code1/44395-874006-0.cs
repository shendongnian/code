    Public Function GenSQLCmd(ByVal InSqlCmd As String, ByVal p As Data.Common.DbParameterCollection) As String
        For Each x As Data.Common.DbParameter In p
            InSqlCmd = Replace(InSqlCmd, x.ParameterName, x.Value.ToString)
        Next
        Return InSqlCmd
    End Function
