    private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            string Query = "insert into Professeur values ("+ txtID.Text +", '" + txtNom.Text + "', '" + txtPrenom.Text + "', '" + dtNaiss.Text + 
                "', '"+ txtEmail.Text +"', '"+ txtPass.Text +"', '" + dtAff.Text + "', '" + cbEtat.Text + "', "+ txtNum.Text +", " + cbLycee.Text + ")";
            cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
