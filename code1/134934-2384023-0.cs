    foreach (Business.IEditeur editeur in _livreManager.GetPublishers())
    {
        //comboPublisher.Items.Add(editeur);
        list.Add(editeur);
    }
    combobox.ItemsSource = editeur;
