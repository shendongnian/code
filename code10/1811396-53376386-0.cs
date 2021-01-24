    public partial class Form1 : Form
    {
        //Variables
        string srvName;
        string mapSelect;
        string mapFile;
        string difSelect;
        string difFile;
        int maxPlayers;
        string plrSelect;
        string plrFile;
        string finalFile;
        string basepath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string fileName = "config.txt";
        public Form1()
        {
            InitializeComponent();
            this.srvList.SelectedIndexChanged += new System.EventHandler(this.srvList_SelectedIndexChanged);
        }
        private void srvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Read Server Selection
            string srvSelect = srvList.GetItemText(srvList.SelectedItem);
            string srvOut = System.IO.Path.Combine(basepath, srvSelect, fileName);
            mapFile = File.ReadLines(srvOut).Skip(1).Take(1).First();
            difFile = File.ReadLines(srvOut).Skip(2).Take(1).First();
            plrFile = File.ReadLines(srvOut).Skip(3).Take(1).First();
            //Display Server Selection
            if (srvList.SelectedIndex == -1)
            {
                dltButton.Visible = false;
            }
            else
            {
                dltButton.Visible = true;
                mapLabel1.Text = mapFile;
                difLabel1.Text = difFile;
                plrLabel1.Text = plrFile;
        }
        private void crtButton_Click(object sender, EventArgs e)
        {
            //Set Server Name
            srvName = namBox1.Text;
            string finalpath = System.IO.Path.Combine(basepath, srvName);
            //Check if server name is taken
            if (System.IO.Directory.Exists(finalpath))
            {
                MessageBox.Show("A Server by this name already exists");
            }
            else
            {
                //Add Server to the Server List
                srvList.Items.Add(srvName);
                //Server Configuration
                mapSelect = mapBox1.Text;
                difSelect = difBox1.Text;
                maxPlayers = maxBar1.Value * 2;
                plrSelect = "" + maxPlayers;
                //Clear New Server Form
                namBox1.Text = String.Empty;
                mapBox1.SelectedIndex = -1;
                difBox1.SelectedIndex = -1;
                //Create the Server File
                Directory.CreateDirectory(finalpath);
                finalFile = System.IO.Path.Combine(finalpath, fileName);
                File.Create(finalFile).Close();
                //Write to config file
                string[] lines = { srvName, mapSelect, difSelect, plrSelect };
                System.IO.File.WriteAllLines(@finalFile, lines);
                //Return to srvList
                newPanel.Visible = false;
            }
        }
    }
