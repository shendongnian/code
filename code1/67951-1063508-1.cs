        public Form1()
        {
            InitializeComponent();
        }
        void Form1_Load(object sender, EventArgs e)
        {
            RegisterButtonEvents();
        }
        void RegisterButtonEvents()
        {
            userControl11.ButtonOK.Click += new EventHandler(ButtonOK_Click);
            userControl21.ButtonOK.Click += new EventHandler(ButtonOK_Click);
        }
        void ButtonOK_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Name == "btn1")
                {
                    Console.WriteLine(" ButtonOK from UserControl1 was pushed. The tag is " + btn.Tag.ToString());
                }
                else if (btn.Name == "btn2")
                {
                    Console.WriteLine(" ButtonOK from UserControl2 was pushed. The tag is " + btn.Tag.ToString());
                }
            }
        }
