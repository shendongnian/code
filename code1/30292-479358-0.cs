    public Form1()
    {
            InitializeComponent(); 
            /*  --- Old code that don't work ---
                this.panel1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
                this.panel1.MouseMove += new MouseEventHandler(panel1_MouseWheel);
            */
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
            this.MouseMove += new MouseEventHandler(panel1_MouseWheel);
            Form2 f2 = new Form2();
            f2.Show(this);
        }
    }
