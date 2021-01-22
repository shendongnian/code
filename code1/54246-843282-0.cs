    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class AddressCollection : BindingList<Address>
    {
        public void Add(string line1, string zip)
        { // just for convenience
            Add(new Address { Line1 = line1, Zip = zip});
        }
    }
    
    class Address
    {
        public string Line1 { get; set; }
        public string Zip { get; set; }
    
        public override string ToString()
        {
            return Line1;
        }
    }
    class Contact
    {
        public string Name { get; set; }
        private readonly AddressCollection addresses = new AddressCollection();
        public AddressCollection Addresses { get { return addresses; } }
        public override string ToString()
        {
            return Name;
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            BindingList<Contact> contacts = new BindingList<Contact>
            {
                new Contact { Name = "Fred", Addresses = { {"123 Some road", "AB1"}}},
                new Contact { Name = "Barney", Addresses = { {"456 A Street", "CD2"}, {"789 The Lane", "EF3"}}}                
            };
            BindingSource bs = new BindingSource(contacts, "");
           
            Form form = new Form { 
                Controls = {
                                    new DataGridView { Dock = DockStyle.Fill, DataSource = bs, DataMember = "Addresses" },
                    new ComboBox { Dock = DockStyle.Top, DataSource = bs, DisplayMember = "Name" },
                    new TextBox { Dock = DockStyle.Bottom, DataBindings = { {"Text", bs, "Addresses.Zip"}}}
                }
            };
            Application.Run(form);
    
        }
    }
