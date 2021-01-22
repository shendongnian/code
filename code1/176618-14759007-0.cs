      Try
            Dim sqltxt As String = "SELECT * FROM mplib.pfcarfib where LOTEF=" & My.Settings.loteproceso
            dt1 = New DataTable
            Dim ConAS400 As New OleDb.OleDbConnection
            ConAS400.ConnectionString = "Provider=IBMDA400;" & _
            "Data Source=192.168.100.100;" & _
            "User ID=" & My.Settings.usuario & ";" & _
            "Password=" & My.Settings.contrasena
            Dim CmdAS400 As New OleDb.OleDbCommand(sqltxt, ConAS400)
            Dim sqlAS400 As New OleDb.OleDbDataAdapter
            sqlAS400.SelectCommand = CmdAS400
            ConAS400.Open()
            sqlAS400.Fill(dt1)
            grid_detalle.DataSource = dt1
            grid_detalle.DataMember = dt1.TableName
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Comunicación Con El AS400 No Establecida, Notifique a Informatica..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
