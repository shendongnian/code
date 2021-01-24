    public async void OnEdit(object sender, EventArgs e) { 
        Contact contact = ((MenuItem)sender).CommandParameter as Contact;
        if(contact != null) {
            var contactPage = new ContactPage(contact);
            await Navigation.PushAsync(contactPage);
        }
    }
