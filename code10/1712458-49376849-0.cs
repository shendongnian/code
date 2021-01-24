    void NewContact(out string backup)
    {
        backup = string.Empty; // Or any value that your logic needs.
        string contact = SnapsEngine.ReadString("Enter the contact name");
        string address = SnapsEngine.ReadMultiLineString("Enter " + contact + " address");
        string number = SnapsEngine.ReadString("Enter " + contact + " number");
        Storeinfo(contact: contact, address: address, number: number);
        backup = backup + contact;
    
        SnapsEngine.WaitForButton("Continue");
    }
