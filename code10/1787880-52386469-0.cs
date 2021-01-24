        async void MenuItem_Clicked(object sender, EventArgs e)
        {
            if (_nm != null)
            {
                await _connection.DeleteAsync(_nm);
                _nahrungsmittel.Remove(_nm);
            }
        }
        private void speisenListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           if (e.SelectedItem is Nahrungsmittel nm)
            {
                _nm = nm;
            }
        (BindingContext as EssenBestellen.ViewModels.NahrungsmittelListeViewModel).SelectNahrungsmittel(e.SelectedItem as Nahrungsmittel);
        
        }
    
