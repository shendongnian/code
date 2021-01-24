    public Dictionary<string, MyObject> GetGroupDataFromDatabase()
    {
        var globals = new Globals();
        
        using (var sqlConnection = new SqlConnection((globals.Comms()))) // If you can, I'd rename Comms too.
        using (var sqlCommand = new SqlCommand("SELECT BrzaGrupaBroj, BrzaGrupaNaziv, BrzaGrupaColor FROM BrzaGrupaGUI", sqlConnection))
        using (var sqlAdapter = new SqlDataAdapter(sqlCommand))
        {
            var dataTable = new DataTable();
            
            try
            {
                sqlConnection.Open();
                sqlAdapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Do something with the exception, like logging
            }
            
            var myDictionary = new Dictionary<string, MyObject>();
            
            foreach (var row in dataTable.Rows)
            {
                var newObject = new MyObject(row);
                myDictionary.Add(newObject.brzaGrpBr, newObject);
            }
            
            return myDictionary;
        }
    }
