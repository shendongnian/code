    public partial class Form1 : Form
    {
        // Declare your controls at the class level so all methods can access them
        private TextBox dbname;
        private Button create;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dbName = new TextBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(236, 81)
            };
            Controls.Add(dbName);
            create = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Location = new Point(261, 115),
                Text = "Create",
            };
            create.FlatAppearance.BorderSize = 0;
            create.Click += Create_Click;
            Controls.Add(create);
        }
        private void Create_Click(object sender , EventArgs e)
        {
            SaveFileDialog _sfd_ = new SaveFileDialog();
            _sfd_.Filter = "Housam Printing |*.HP";
            _sfd_.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _sfd_.FileName = dbname.text;
            _sfd_.Title = "Database location";
        }
    }        
