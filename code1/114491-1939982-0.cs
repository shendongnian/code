    public ActionResult Edit(ContactViewModel viewModel)
    {
        var contact = repository.GetContacts().WithId(viewModel.Id);
        // Update the contact with the fields from the viewModel
        repository.Save(contact);
    }
        
