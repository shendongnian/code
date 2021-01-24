    public partial class MainControl : UserControl
    {
        private Custom_UI.MainMenu mainMenu = new Custom_UI.MainMenu();
        public MainControl()
        {
            InitializeComponent();
            mainMenu.Visible = false;
            mainMenu.BringToFront();            
            this.Controls.Add(mainMenu);
            mainMenu.BringToFront();
            this.Click += me_Click;
        }
        private void me_Click(object sender, EventArgs e)
        {
            this.Focus(); //this will cause main control to get control (if main menu is focused it'll lose focus and handle it's focus lost and set visible to false in result
        }
        private void menuButton1_Click(object sender, EventArgs e)
        {
            if (mainMenu.Visible)
            {
                mainMenu.Visible = false;   // this should work anyway
            }
            else
            {
                mainMenu.Visible = true;
                mainMenu.Focus(); //when showing mainMenu set focus to it
            }
        }
    }
