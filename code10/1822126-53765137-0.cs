    private void Listboxspelers_SelectionChanged(object sender, SelectionChangedEventArgs e){
        if(listboxspelers.SelectedItem != null){
            lblpositie.Content = "Positie: " + db.GetPositie(listboxspelers.SelectedItem.ToString());
            lbldoelpunten.Content = "Aantal Doelpunten: " + db.GetDoelpunten(listboxspelers.SelectedItem.ToString());
            lblgelekaarten.Content = "Aantal GeleKaarten: " + db.GetGeleKaarten(listboxspelers.SelectedItem.ToString());
            lblRodeKaarten.Content = "Aantal RodeKaarten: " + db.GetRodeKaarten(listboxspelers.SelectedItem.ToString());
        }
    }
