    Public Class New_DAL
    Public Function Combo1(ByVal cmb1select As String) As DataTable
        'Not included in the snippet a assume it is coded this way
        Dim cmd As SqlClient.SqlCommand
        Dim con As SqlClient.SqlConnection
        Dim dr As SqlClient.SqlDataReader
        con = New SqlClient.SqlConnection("your_connection_string")
        con.Open()
        '----------
        'New Code
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        '----------
        cmd = New SqlClient.SqlCommand("Select Name from table1", con)
        dr = cmd.ExecuteReader
        While (dr.Read())
            'old code
            'cmb1select = (dr("Name"))
            'New Code
            dt.Rows.Add(dr("Name"))
            '----------
        End While
        'Not included in the snippet a assume it is coded this way
        con.Close()
        '----------
        'old code
        'Return dr
        Return dt
    End Function
    End Class
