    Dim dtCustomer = New DataTable("Customer")
            dtCustomer.Columns.Add("CId", GetType(Integer))
            dtCustomer.Columns.Add("FirstName", GetType(String))
            dtCustomer.Columns.Add("LastName", GetType(String))
            dtCustomer.Columns.Add("Email", GetType(String))
    
            For Each q In query
                dtCustomer.Rows.Add(New Object() {q.CId, q.FirstName, q.LastName, q.Email})
            Next
