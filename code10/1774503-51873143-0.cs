         private void search_btn_Click(object sender, EventArgs e)
            {
                con.Open();
                cmd.Connection = con;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM[FAUF] WHERE Auftragsnummer = '" + txt_search.Text + "'", con);
                mdr = myCommand.ExecuteReader();
    
                if (!mdr.Read())
                {
                    txt_searchNr.Text = "---";
                    txt_searchSF.Text = "---";
                    txt_search.SelectAll();
                    MessageBox.Show("Keine Daten gefunden - Bitte überprüfen Sie Ihre Eingaben!");
                    con.Close();
                    return;
                }
    
                while (mdr.Read())
                {
                    //Do your code here
                }
    
                con.Close();
            }
