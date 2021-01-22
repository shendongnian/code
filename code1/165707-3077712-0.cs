    public delegate void HandleItemAdded(object sender, ItemAddedEventArgs e);    
    public struct ItemAddedEventArgs : EventArgs
    {
        public string Name;
        public string Email;
        public string Phone;
        public ItemAddedEventArgs(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
