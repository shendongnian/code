                Private Function DecodeJsonString(ByVal Input As String) As String
                For Each m As System.Text.RegularExpressions.Match In New System.Text.RegularExpressions.Regex("\\u(\w{4})").Matches(Input)
                    Input = Input.Replace(m.Value, Chr(CInt("&H" & m.Value.Substring(2))))
                Next
                Return Input
                End Function
