    Imports System.Management
    
       
    
        Private Sub InsertInfo()
        			lstView.Items.Clear()
        
        			Dim searcher As New ManagementObjectSearcher("select * from Win32_Processor")
        
        			Try
        				For Each share As ManagementObject In searcher.Get()
        
        					Dim grp As ListViewGroup
        					Try
        						grp = lstView.Groups.Add(share("Name").ToString(), share("Name").ToString())
        					Catch
        						grp = lstView.Groups.Add(share.ToString(), share.ToString())
        					End Try
        
        					If share.Properties.Count <= 0 Then
        						MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        						Return
        					End If
        					
        			
        					For Each PC As PropertyData In share.Properties
        
        						Dim item As New ListViewItem(grp)
        						If lstView.Items.Count Mod 2 <> 0 Then
        							item.BackColor = Color.White
        						Else
        							item.BackColor = Color.WhiteSmoke
        						End If
        
        						item.Text = PC.Name
        
        						If PC.Value IsNot Nothing AndAlso PC.Value.ToString().Length > 0 Then
        							Select Case PC.Value.GetType().ToString()
        								Case "System.String[]"
        									Dim str As String() = DirectCast(PC.Value, String())
        
        									Dim str2 As String = ""
        									For Each st As String In str
        										str2 += st & " "
        									Next
        
        									item.SubItems.Add(str2)
        
        									Exit Select
        								Case "System.UInt16[]"
        									Dim shortData As UShort() = DirectCast(PC.Value, UShort())
        
        
        									Dim tstr2 As String = ""
        									For Each st As UShort In shortData
        										tstr2 += st.ToString() & " "
        									Next
        
        									item.SubItems.Add(tstr2)
        
        									Exit Select
        								Case Else
        
        									item.SubItems.Add(PC.Value.ToString())
        									Exit Select
        							End Select
        						Else
        							Continue For
        						End If
        						lstView.Items.Add(item)
        					Next
        				Next
        
        
        			Catch exp As Exception
        				MessageBox.Show("can't get data because of the followeing error " & vbLf & exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        			End Try
        
        
        			End Sub
