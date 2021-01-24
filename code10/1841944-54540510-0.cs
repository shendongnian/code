    protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginGebruikersNaam = txtGebruikersNaam.Text;
            LoginWachtwoord = txtWachtwoord.Text;
            var tupleDetails = B.Inloggen(LoginGebruikersNaam, LoginWachtwoord);
            lblMessage.Text = tupleDetails.Item1;
            Ingelogd = tupleDetails.Item2;
        }
 
