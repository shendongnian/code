    string[] aInfo; // Contains information about this person
    
    ....
    ....
    // Event for adding contact
    mContact.Click += new EventHandler(addContactMenuClick);
    mContact.Tag = aInfo;
    // Eventhandler for adding a contact
    private void addContactMenuClick(object sender, System.EventArgs e)
    {
        string sNumber = ((MenuItem)sender).Text;
        string[] aInfo = (string[])((MenuItem)sender).Tag;
        MessageBox.Show(sNumber);
    }
