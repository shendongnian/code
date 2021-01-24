    public bool InserisciLibro(LibroCLS libro)
        {
            bool isSuccess = false;
            using (OleDbConnection con = new OleDbConnection(myConnectionstring))
            {
                con.Open();
                string SQL =@"INSERT INTO tblLibri (AutoreFK, Titolo,   Pagine,  EditoreFK, ISBN,   Notes) VALUES (@AutoreFK, @Titolo, @Pagine, @EditoreFK, @ISBN, @Notes);";
                int idnewlibro = 0;
                using (OleDbCommand cmd = new OleDbCommand(SQL, con))
                {
                    cmd.Parameters.AddWithValue("@AutoreFK",libro.AutoreFK);
                    cmd.Parameters.AddWithValue("@Titolo", libro.Titolo);
                    cmd.Parameters.AddWithValue("@Pagine", libro.Pagine);
                    cmd.Parameters.AddWithValue("@EditoreFK", libro.EditoreFK);
                    cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    cmd.Parameters.AddWithValue("@Notes", libro.Notes);
                    int row = cmd.ExecuteNonQuery();
                    //ora lancio il cmd per ottenere l'id autoincrementale ottenuto
                    OleDbCommand cmdIdentity = new OleDbCommand("SELECT @@IDENTITY", con);                    
                    idnewlibro =(int) cmdIdentity.ExecuteScalar();
                    if (idnewlibro != 0)
                    {
                        isSuccess = true;
                    }                   
                }
            }
            return isSuccess;
        }
