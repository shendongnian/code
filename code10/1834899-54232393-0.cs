    int count = collision.collider.GetContacts(contacts);
    if(count > contacts.Length)
    {
        Array.Resize(ref contacts, count);
        collision.collider.GetContacts(contacts);
    }
