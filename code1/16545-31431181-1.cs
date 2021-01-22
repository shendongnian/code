	Dim query As String = cmd.CommandText
	query = query.Replace("SET", "SET" & vbNewLine)
	query = query.Replace("WHERE", vbNewLine & "WHERE")
	query = query.Replace("GROUP BY", vbNewLine & "GROUP BY")
	query = query.Replace("ORDER BY", vbNewLine & "ORDER BY")
	query = query.Replace("INNER JOIN", vbNewLine & "INNER JOIN")
	query = query.Replace("LEFT JOIN", vbNewLine & "LEFT JOIN")
	query = query.Replace("RIGHT JOIN", vbNewLine & "RIGHT JOIN")
	If query.Contains("UNION ALL") Then
		query = query.Replace("UNION ALL", vbNewLine & "UNION ALL" & vbNewLine)
	ElseIf query.Contains("UNION DISTINCT") Then
		query = query.Replace("UNION DISTINCT", vbNewLine & "UNION DISTINCT" & vbNewLine)
	Else
		query = query.Replace("UNION", vbNewLine & "UNION" & vbNewLine)
	End If
	For Each par In cmd.Parameters
		If par.Value Is Nothing OrElse IsDBNull(par.Value) Then
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", "NULL")
		ElseIf TypeOf par.Value Is Date Then
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", "'" & Format(par.Value, "yyyy-MM-dd HH:mm:ss") & "'")
		ElseIf TypeOf par.Value Is TimeSpan Then
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", "'" & par.Value.ToString & "'")
		ElseIf TypeOf par.Value Is Double Or TypeOf par.Value Is Decimal Or TypeOf par.Value Is Single Then
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", Replace(par.Value.ToString, ",", "."))
		ElseIf TypeOf par.Value Is Integer Or TypeOf par.Value Is UInteger Or TypeOf par.Value Is Long Or TypeOf par.Value Is ULong Then
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", par.Value.ToString)
		Else
			query = RegularExpressions.Regex.Replace(query, par.ParameterName & "\b", "'" & MySqlHelper.EscapeString(CStr(par.Value)) & "'")
		End If
	Next
