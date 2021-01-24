            bool Ingelogd = false;
            string Message = String.Empty;
            string Voornaam = String.Empty, Naam = String.Empty;
            var _LoginGebruikersNaam = LoginGebruikersNaam;
            var _LoginWachtwoord = LoginWachtwoord;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmdInloggen = new SqlCommand("SPInloggen", sqlConnection))
                    {
                        cmdInloggen.CommandType = CommandType.StoredProcedure;
                        cmdInloggen.Parameters.AddWithValue("@LoginGebruikersNaam", _LoginGebruikersNaam);
                        cmdInloggen.Parameters.AddWithValue("@LoginWachtwoord", _LoginWachtwoord);
                        sqlConnection.Open();
                        using (SqlDataReader drInloggen = cmdInloggen.ExecuteReader())
                        {
                            while (drInloggen.Read())
                            {
                                Voornaam = drInloggen[0].ToString();
                                Naam = drInloggen[1].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.ToString();               
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
            return new Tuple<string, bool>(Message, Ingelogd);
        }
