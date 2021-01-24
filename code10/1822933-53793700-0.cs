    public List<Transactie> FillTransacties()
    {
        try
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT transactieID, opdrachtID, medewerkerID, soort, datum, bedrag FROM Financien", connection);
            SqlDataReader transactieinformatie = cmd.ExecuteReader();
            List<Transactie> transacties = new List<Transactie>();
            while (transactieinformatie.Read())
            { 
                    string transactieID = transactieinformatie["transactieID"].ToString();
                    string opdrachtID = transactieinformatie["opdrachtID"].ToString();
                    string medewerkerID = transactieinformatie["medewerkerID"].ToString();
                    string soort = transactieinformatie["soort"].ToString();
                    string datum = transactieinformatie["datum"].ToString();
                    string bedrag = transactieinformatie["bedrag"].ToString();
                    Transactie transactie = new Transactie(transactieID, opdrachtID, medewerkerID, soort, datum, bedrag);
                    transacties.Add(transactie);  
            }
            return transacties;
        }
        catch (InvalidCastException ICE)
        {
            MessageBox.Show("De data in de database is incorrect", ICE.Message);
            return new List<Transactie>();
        }
        catch (Exception e)
        {
            MessageBox.Show("Er is een onbekende error opgetreden.", e.Message);
            return new List<Transactie>();
        }
        finally
        {
            connection.Close();
        }
    }
