    public Form1()
            {
                InitializeComponent();
                ContactList C = new ContactList();
                C.Add(new Contact("Name","Jid","Group"));
                C.Add(new Contact());
                C.Add(new Contact("Test","2","Something"));
                for (int i = 0; i < C.Count; i++)
                {
                    listView1.Items.Add(C[i].ToString());
                }
            }
