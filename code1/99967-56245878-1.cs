        Dim xe As New XElement("l", New XElement("i", "ITEM-A"), New XElement("i", "ITEM-B"))
        Using conn As New OracleConnection(myConnectionString)
            conn.Open()
            Using cmd As OracleCommand = conn.CreateCommand()
                cmd.CommandType = CommandType.Text
                Dim query As String
                query = "  SELECT s.FOO, q.BAR " & vbCrLf
                query &= " FROM TABLE1 s LEFT OUTER JOIN " & vbCrLf
                query &= "      TABLE2 q ON q.ID = s.ID " & vbCrLf
                query &= " WHERE (COALESCE(q.ID, 'NULL') NOT LIKE '%OPTIONAL%') AND "
                query &= "       (s.ID IN ("
                query &= "                      SELECT stid "
                query &= "                      FROM XMLTable('/l/i' PASSING XMLTYPE(:stid) COLUMNS stid VARCHAR(32) PATH '.')"
                query &= "                 )"
                query &= "        )"
                cmd.CommandText = query
                Dim parameter As OracleParameter = cmd.Parameters.Add("stid", OracleDbType.NVarchar2, 4000)
                parameter.Value = xe.ToString
                Using r As OracleDataReader = cmd.ExecuteReader
                    While r.Read()
                        //Do something
                    End While
                End Using
            End Using
            conn.Close()
