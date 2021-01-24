    public class ContactRecord
    {
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
    ContactRecord NewContact ()
    {
        string contact = SnapsEngine.ReadString("Enter the contact name");
        string address = SnapsEngine.ReadMultiLineString("Enter " + contact + " address");
        string number = SnapsEngine.ReadString("Enter " + contact + " number");
        return new ContactRecord { Contact = contact, Address = address, Number = number };
    }
