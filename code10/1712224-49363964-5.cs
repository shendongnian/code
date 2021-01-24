    foreach (var contact in Contacts)
    {
        if (contact.IsFavourite)
        {
            Task.Factory.StartNew(() =>
            {
               ContactController.GetLeagues(contact);
            })
            .ContinueWith((prevTask) =>
            {
               CheckTaskException(prevTask);
            });
        }
    }
