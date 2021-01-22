        Public Shared Function SqlString(ByVal cmd As SqlCommand) As String
        Dim sbRetVal As New System.Text.StringBuilder()
        For Each item As SqlParameter In cmd.Parameters
            Select Case item.DbType
                Case DbType.String
                    sbRetVal.AppendFormat("DECLARE {0} AS VARCHAR(255)", item.ParameterName)
                    sbRetVal.AppendLine()
                    sbRetVal.AppendFormat("SET {0} = '{1}'", item.ParameterName, item.Value)
                    sbRetVal.AppendLine()
                Case DbType.DateTime
                    sbRetVal.AppendFormat("DECLARE {0} AS DATETIME", item.ParameterName)
                    sbRetVal.AppendLine()
                    sbRetVal.AppendFormat("SET {0} = '{1}'", item.ParameterName, item.Value)
                    sbRetVal.AppendLine()
                Case DbType.Guid
                    sbRetVal.AppendFormat("DECLARE {0} AS UNIQUEIDENTIFIER", item.ParameterName)
                    sbRetVal.AppendLine()
                    sbRetVal.AppendFormat("SET {0} = '{1}'", item.ParameterName, item.Value)
                    sbRetVal.AppendLine()
                Case DbType.Int32
                    sbRetVal.AppendFormat("DECLARE {0} AS int", item.ParameterName)
                    sbRetVal.AppendLine()
                    sbRetVal.AppendFormat("SET {0} = {1}", item.ParameterName, item.Value)
                    sbRetVal.AppendLine()
                Case Else
                    Stop
            End Select
        Next
        sbRetVal.AppendLine("")
        sbRetVal.AppendLine(cmd.CommandText)
        Return sbRetVal.ToString()
    End Function
