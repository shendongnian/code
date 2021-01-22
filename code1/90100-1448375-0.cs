    private void Form1_Load(object sender, EventArgs e)
        {
           // System.Windows.Forms.MdiClient mdiClient = new System.Windows.Forms.MdiClient();
           //  mdiClient.Dock = DockStyle.Fill;
           // mdiClient.BackColor = Color.WhiteSmoke;
           // this.Controls.Add(mdiClient);
           this.IsMdiContainer = true;
            int processID = StartCMD();
            AddToMDIClient(processID, mdiClient.Handle);
        }
