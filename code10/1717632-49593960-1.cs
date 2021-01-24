    private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Open();
            string Query = "UPDATE Professeur SET nom = '" + txtNom.Text + "', prenom = '" + txtPrenom.Text +
                "', dateN = '" + dtNaiss.Text + "', email = '" + txtEmail.Text + "', pass = '"+ txtPass.Text +"' , dateAffLycee = '" + dtAff.Text +"' , nEfants = '" +txtNum.Text+
                "', idLycee = '" + cbLycee.Text + "' WHERE idProfesseur = " + txtID.Text;
            cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
