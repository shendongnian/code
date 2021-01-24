    private void Listboxspelers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //set player statistics
        if (listboxspelers != null && listboxspelers.SelectedItem != null)
        {
            string selectedItem = listboxspelers.SelectedItem.ToString();
            lblpositie.Content = "Positie: " + db.GetPositie(selectedItem);
            lbldoelpunten.Content = "Aantal Doelpunten: " + db.GetDoelpunten(selectedItem);
            lblgelekaarten.Content = "Aantal GeleKaarten: " + db.GetGeleKaarten(selectedItem);
            lblRodeKaarten.Content = "Aantal RodeKaarten: " + db.GetRodeKaarten(selectedItem);
        }
    }
