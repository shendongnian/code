    public void InsertElement(string link, string titolo, string text, SqlConnection conn)
    {
        text = text.Replace("\"", "");
        DateTime localDate = DateTime.Now;
        lock (thisLock)
        {
            string query = "IF (NOT EXISTS(SELECT * FROM Result " +
                            " WHERE Link = '" + link + "')) " +
                            " BEGIN " +
                            " INSERT INTO Result ([Titolo],[Link],[Descrizione],[DataRicerca],[FKDatiRicercheID]) " +
                                " VALUES('" + titolo + "', '" + link + "', '" + text + "', '" + localDate + "', 1) " +
                                " END";
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
