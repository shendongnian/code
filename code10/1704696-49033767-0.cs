    struct contactInfo
        {
            public string FirstName;
            public string Surname;
            public string Phone;
        }
    private void insertContacts (List<contactInfo> pList)
    {
    using (OleDbConnection conn1 = new OleDbConnection(ConnString))
        {            
                conn1.Open();
                
            foreach (contactInfo info in pList)
            {
               using (OleDbCommand cmd1 = new OleDbCommand(internalContact, conn1))
                {
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("FirstName", OleDbType.VarChar).Value = info.FirstName;
                cmd1.Parameters.Add("Surname", OleDbType.VarChar).Value = info.Surname;                  
                cmd1.Parameters.Add("Phone", OleDbType.VarChar).Value = info.Phone;
                cmd1.ExecuteNonQuery();
                 }
               }
                conn1.Close();
            }
        }
