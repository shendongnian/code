    foreach (Business.IEditeur editeur in _livreManager.GetPublishers())
    {
        //comboPublisher.Items.Add(editeur);
        list.Add(editeur);
    }
    combobox.ItemsSource = editeur;
    combobox.SelectedValuePath = "value_property_name";
    combobox.DisplayMemberPath = "display_property_name";
