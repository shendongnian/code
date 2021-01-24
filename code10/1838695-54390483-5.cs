    string query = @"insert into produits
                    (ref_pdt, designation_pdt, quantite_pdt, prix_pdt)
                    values (@refp, @desig, @quant, @prix)";
    try {
        using (var conn = loaddatabaseconnexion.connexion_BDD())
        using (var cmd = new SqlCommand(query, conn)) {
            cmd.Parameters.Add("@refp", SqlDbType.NVarChar).Value = tb_ref_add.Text;
            cmd.Parameters.Add("@desig", SqlDbType.NVarChar).Value = tb_des_add.Text;
            cmd.Parameters.Add("@quant", SqlDbType.Int).Value = Int32.Parse(tb_qte_add.Text);
            cmd.Parameters.Add("@prix", SqlDbType.Decimal).Value =
                Decimal.Parse(tb_qte_add.Text);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0) {
                MessageBox.Show("Il y a eu un problème !");
            } else {
                MessageBox.Show("Données sauvegardées !");
                formulaire_principal.tableau();
            }
        }
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
