    string deleteStatement = "DELETE from Test ";
            
    if (listeTest.SelectedIndices.Count != 0)
    {
        foreach (ListViewItem item in listeTest.Items)
        {
            if (item.Selected)
            {
                int id = (int)listeTest.SelectedItems[0].Tag;
                MessageBox.Show("TEST " + id);
                try
                {
                    if (!deleteStatement.Contains("WHERE"))
                    {
                        deleteStatement += "WHERE ID='" + id + "' ";
                    }
                    else
                    {
                         deleteStatement += "OR ID='" + id + "' ";
                    }
                }
                catch
                {
                    MessageBox.Show("Error with SQL query !", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }
        }
    }
    else
    {
        MessageBox.Show("Veuillez selectionner une personne pour pouvoir la supprimer", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    }
    sqlRequete.CommandText = deleteStatement;
    sqlRequete.ExecuteNonQuery();
    listeTest.SelectedItems.Clear();
    chargerListe();
    listeTest.Refresh();
    initSourceGrid();
    MessageBox.Show("Action effectuée !");
