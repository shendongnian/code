        private System.Threading.Timer AutoRunTimer; 
       
        private void Form1_Load(object sender, EventArgs e)
        {
            mybackups = new BackupService();
            AutoRunTimer = new System.Threading.Timer(tick, "", new TimeSpan(0, 0, 5), new TimeSpan(1, 0, 0));     
        }
        private void tick(object data)
        {
            if (DateTime.Now.Hour == 1 && DateTime.Now.Subtract(lastRun).Hours >= 1) // run backups at first opportunity after 1 am
            {
                startBackup("automatically");
            }
        }
