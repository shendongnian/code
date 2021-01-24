    public partial class Form1 : Form
    {
    
        //declare new listbox
        ListBox lbCerts;
    
        public Form1()
        {
            InitializeComponent();
            //add a listbox to the form
            lbCerts = new ListBox();
            lbCerts.DisplayMember = "Name";
            this.Controls.Add(lbCerts);
        }
    
        //class represent certificate
        class myCer
        {
            public string Name { get; set; }
            public string HasPrivateKey { get; set; }
            public string Location { get; set; }
            public string Issuer { get; set; }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var stores = new Dictionary<StoreName, string>()
                {
                    { StoreName.My,"Personal"},
                    { StoreName.Root,"Trusted roots"},
                    { StoreName.TrustedPublisher,"Trusted Publishers"}
                }.Select(s => new { store = new X509Store(s.Key, StoreLocation.LocalMachine), Location = s.Value }).ToArray();
            foreach (var store in stores)
                store.store.Open(OpenFlags.ReadOnly);
            //create list of myCer
            var list = stores.SelectMany(s => s.store.Certificates.Cast<X509Certificate2>().Select(mCert => new myCer
            {
                HasPrivateKey = mCert.HasPrivateKey ? "Yes" : "No",
                Name = mCert.FriendlyName,
                Location = s.Location,
                Issuer = mCert.Issuer
            })).ToList();
            //populate listbox
            lbCerts.DataSource = list;
    
        }
     }
