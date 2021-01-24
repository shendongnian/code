    public partial class Form1 : Form
    {
        // Declare your controls at the class level so all methods can access them
        private TextBox dbName;
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
            create.Click += create_Click;
            Controls.Add(create);
        }
        private void create_Click(object sender , EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Housam Printing |*.HP",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                FileName = dbName.Text,
                Title = "Database location"
            };
        }
    }        
