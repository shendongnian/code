    // Consider renaming to InsertContacts, as it's not just dealing with a single
    // contact
    public string InsertContact(List<PersonContact> contacts)
    {
        // You should almost certainly use a using statement here, to
        // dispose of the connection afterwards
        OpenConnection();
        foreach (var contact in contacts)
        {
            // Insert the contact. Use a using statement for the SqlCommand too.
        }
        return "1";
    }
