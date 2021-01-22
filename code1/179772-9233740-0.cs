       Private Sub txtNetRegex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNetRegex.TextChanged
          If String.IsNullOrEmpty(txtNetRegex.Text) Then
             btnNetALLToDB.Enabled = False
          Else
             btnNetALLToDB.Enabled = True
    
             Dim reg As New Regex(txtNetRegex.Text, RegexOptions.IgnoreCase)
    
             Me._netFilteredNames = New List(Of String)
    
             For Each s As String In Me._netNames
                On Error Resume Next
                If (reg.IsMatch(s)) Then
                   Me._netFilteredNames.Add(s)
                End If
             Next
    
             LoadNetBox()
          End If
       End Sub
       Private Sub LoadNetBox()
          lbxNetwork.Items.Clear()
          lbxNetwork.Refresh()
    
          Dim lst As List(Of String)
          If Me.chkEnableNetFilter.Checked And (Me._netFilteredNames IsNot Nothing) Then
             lst = Me._netFilteredNames
          Else
             lst = Me._netNames
          End If
    
          If lst IsNot Nothing Then
             For Each s As String In lst
                lbxNetwork.Items.Add(s)
             Next
          End If
    
          lbxNetwork.Refresh()
       End Sub
