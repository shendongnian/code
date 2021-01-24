    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LoginGebruikersNaam = txtGebruikersNaam.Text;
        LoginWachtwoord = txtWachtwoord.Text;
        var response = B.Inloggen(LoginGebruikersNaam, LoginWachtwoord);
        lblMessage.Text = response.Item1;
        Ingelogd = response.Item2;
    }
    public Tuple<string, bool> Inloggen(string LoginGebruikersNaam, string LoginWachtwoord)
    {
        bool Ingelogd = false;
        string Message = String.Empty;
        string Voornaam = String.Empty, Naam = String.Empty;
        _LoginGebruikersNaam = LoginGebruikersNaam;
        _LoginWachtwoord = LoginWachtwoord;
        SqlCommand cmdInLoggen = new SqlCommand("SPInloggen", cnn);
        cmdInloggen.CommandType = System.Data.CommandType.StoredProcedure;
        cmdInloggen.Parameters.AddWithValue("@LoginGebruikersNaam", _LoginGebruikersNaam);
        cmdInloggen.Parameters.AddWithValue("@LoginWachtwoord", _LoginWachtwoord);
        try
        {
            cnn.Open();
            drInloggen = cmdInloggen.ExecuteReader();
            if (drInloggen.Read())
            {
                Voornaam = drInloggen[0].ToString();
                Naam = drInloggen[1].ToString();
            }
            if (Voornaam == String.Empty || Naam == String.Empty)
            {
                Message = "De logingegevens kloppen niet! Controleer de gegevens en probeer het opnieuw!";
            }
            else
            {
                Message = "Welkom " + Voornaam + " " + Naam + "! U bent succesvol ingelogd.";
                Ingelogd = true;
            }
        }
        finally
        {
            // Enforce the connection is closed even when exception is raised
            if (cnn.State != System.Data.ConnectionState.Closed) cnn.Close();
        }
        return new Tuple<string, bool>(Message, Ingelogd);
    }
