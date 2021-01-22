    Private Sub ConnectToDB()
            If (File.Exists("\SystemCF\LPI\inventory.sdf")) Then
                Try
                    cn = New SqlCeConnection("Data Source=\SystemCF\LPI\inventory.sdf;Password=")
                    cn.Open()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
    
            ElseIf (File.Exists("\UserCF\LPI\inventory.sdf")) Then
                Try
                    cn = New SqlCeConnection("Data Source=\UserCF\LPI\inventory.sdf;Password=")
                    cn.Open()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
    
            Else
        Try
           If (Not (Directory.Exists("\SystemCF\LPI"))) Then
                    Directory.CreateDirectory("\SystemCF\LPI")
           End If
        
           Dim engine As New SqlCeEngine("Data Source=\SystemCF\LPI\inventory.sdf")
           engine.CreateDatabase()
        
           cn = New SqlCeConnection("Data Source=\SystemCF\LPI\inventory.sdf")
           cn.Open()
        
           Call dropAndCreateDatabase()
         Catch ex As Exception
           MessageBox.Show(ex.Message)
           MessageBox.Show("Unable to create database!", "Database Create Failed")
         End Try
    End Sub
