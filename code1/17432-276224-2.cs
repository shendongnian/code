    namespace CloudNavigation
    {
        public partial class Test : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    this.recreateButtons();
                }
                else
                {
                    // Execute heavy search 1 to generate buttons
                    Button b = new Button();
                    b.Text = "Selection 1";
                    b.Command += new CommandEventHandler(b_Command);
                    Panel1.Controls.Add(b);
                    //store this stuff in ViewState for the very first time
                }
            }
    
            void b_Command(object sender, CommandEventArgs e)
            {
                //Execute heavy search 2 to generate new buttons
                //TODO: store data into ViewState or Session
                //and maybe create some new buttons
            }
            
            void recreateButtons()
            {
                //retrieve data from ViewState or Session and create all the buttons
                //wiring them up to eventHandler
            }
        }
    }
