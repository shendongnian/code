        public bool UserClosing { get; set; }
        public FormMain()
        {
            InitializeComponent();
            UserClosing = false;
            this.buttonExit.Click += new EventHandler(buttonExit_Click);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        void buttonExit_Click(object sender, EventArgs e)
        {
            UserClosing = true;
            this.Close();
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.UserClosing:
                    if (UserClosing)
                    {
                        //what should happen if the user hitted the button?
                    }
                    else
                    {
                        //what should happen if the user hitted the x in the upper right corner?
                    }
                    break;
                case CloseReason.WindowsShutDown:
                    break;
                default:
                    break;
            }
        }
