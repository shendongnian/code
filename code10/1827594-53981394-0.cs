    public partial class Form1 : Form //Change the default "form1" "Button1" etc names as soon as possible
    {
        private bool loginScreenVar = true; //when naming booleans, use "truth test" sounding names like isLoginScreenMode
        private bool mainScreenVar = true;
        public Form1() //this is a constructor, a method that is always called when a new instance of this object is created
        {
            InitializeComponent();
            //use the constructor to set things up
            loginScreenVar = true;
            mainScreenVar = false;
            ChangeScreen();//make sure loginscreen is showing
        }
    
        public void ChangeScreen()
        {
            //Login Screen
            txtUsername.Visible = loginScreenVar;
            txtPassword.Visible = loginScreenVar;
            btnLogin.Visible = loginScreenVar;
            lblLoginCaption.Visible = loginScreenVar;
            lblUsername.Visible = loginScreenVar;
            lblPassword.Visible = loginScreenVar;
            //Main Screen
            lblWelcomeUser.Visible = mainScreenVar;
            btnViewDetails.Visible = mainScreenVar;
            btnViewAccounts.Visible = mainScreenVar;
            btnLogout.Visible = mainScreenVar;
    
            MessageBox.Show(loginScreenVar.ToString());
        }
        //call this method when the login is correct
        public void LoginCorrect()
        {
            loginScreenVar = false;
            mainScreenVar = true;
            ChangeScreen();
        }
        //double click your login button in the forms designer to add this click event handler
        public void LoginButton_Clicked(object sender, ClickEventArgs e){
            if(txtUsername.Text == "user" && txtPassword.Text == "pass"){
                LoginCorrect();
            } else {
                MessageBox.Show("Login incorrect");
            }
        }
    }
