            ProActive.Contact currentContact = (ProActive.Contact)ItemsListBox.Items.CurrentItem;
            
            switch (MessageBox.Show("Are you sure?", "Save Changes", MessageBoxButton.YesNoCancel))
            {
                case MessageBoxResult.Yes:
                    if (currentContact.EntityState == System.Data.EntityState.Detached)
                        ProActive.App.ProActiveDatabaseEntities.Contacts.AddObject(currentContact);
                    ProActive.App.ProActiveDatabaseEntities.SaveChanges();
                    this.RaiseEvent(new RoutedEventArgs(NewItemAddedEvent, this));
                    break;
    }
