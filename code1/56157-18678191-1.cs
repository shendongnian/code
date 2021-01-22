    Private sw As IO.StreamWriter
    
    Public Sub ExecuteBackup()
    	Try
    
    		Dim mysqlDump As New Process
    		mysqlDump.StartInfo.FileName = "PahtToMysqlDump\mysqldump.exe"
    		mysqlDump.StartInfo.Arguments = "--user=myuser --password=mypassword --routines --all-databases"
    		mysqlDump.StartInfo.RedirectStandardOutput = True
    		mysqlDump.StartInfo.CreateNoWindow = True
    		mysqlDump.StartInfo.UseShellExecute = False
    		
    		Console.WriteLine("Arguments:")
    		Console.WriteLine("mysqldump.exe " & mysqlDump.StartInfo.Arguments)
    
    		sw = New IO.StreamWriter("backup.sql")
    
    		AddHandler mysqlDump.OutputDataReceived, AddressOf mysqlDumpNewData
    		
    		mysqlDump.Start()
    		mysqlDump.BeginOutputReadLine()
    		mysqlDump.WaitForExit()
    
    		sw.Close()
    
    		Console.WriteLine("Backup completed")
    		
    	Catch ex As Exception	
    		Console.WriteLine("BackupEngine.ExecuteBackup.", ex)		
    	End Try
    End Sub
    
    Private Sub mysqlDumpNewData(sender As Object, e As DataReceivedEventArgs)
    
    	Dim line = e.Data
    	If line IsNot Nothing Then
    		sw.WriteLine(line)
    		If line.StartsWith("USE") Then
    			Dim ln = line.Split("`")(1)
    			Console.WriteLine("Database : " & ln.ToUpper)
    		End If
    		If line.StartsWith("CREATE TABLE") Then
    			Dim ln = line.Split("`")(1)
    			Console.WriteLine(" Table : " & ln.ToUpper)
    		End If
    	End If
    
    End Sub
