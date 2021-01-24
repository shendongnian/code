            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select name , rollId from demotable ", connection);
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()){
                       dynamic document = new Document();
                       document.name = reader["name"].ToString(); 
                       document.rollId = reader["rollId"].ToString();
                       InsertDoc(client, UriFactory.CreateDocumentCollectionUri("FamilyDB", "FamilyCollection"), document);
                    }
                }
            }
