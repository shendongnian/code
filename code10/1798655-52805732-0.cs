     public Form1()
        {
            InitializeComponent();
            t.Tick += new EventHandler(Timer_Tick);
            t.Interval = 1000;
            t.Enabled = true;                       
            t.Start();
            Form2 TheForm2 = new Form2();
            TheForm2.ShowDialog();
            TheForm2.Visible = false;
        }
