    public frMain()
        {
            InitializeComponent();
            StartSession();
            //SessionChecker();
        }
        public void StartSession()
       {
           try
           {
              usersession.BeginTimer();
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
           
       }
