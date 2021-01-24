        Dim con As SqlConnection = New SqlConnection("server = ADITYA\CBOWR; database = adi; integrated security = true;")
        Dim cmd As SqlCommand = New SqlCommand()
        Dim query As String = "Select * from address"
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query
        Dim sda As SqlDataAdapter = New SqlDataAdapter(query, con)
        Dim ds As DataSet = New DataSet()
        con.Open()
        sda.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
