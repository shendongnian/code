        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Execute heavy search 1 to generate buttons
                ButtonTexts = new ButtonState[] { 
                    new ButtonState() { ID = "Btn1", Text = "Selection 1" } 
                };
            }
            AddButtons();
        }
        void b_Command(object sender, CommandEventArgs e)
        {
            TextBox1.Text = ((Button)sender).Text;
            // Execute heavy search 2 to generate new buttons
            ButtonTexts = new ButtonState[] { 
                new ButtonState() { ID = "Btn1", Text = "Selection 1" }, 
                new ButtonState() { ID = "Btn2", Text = "Selection 2" } 
            };
            AddButtons();
        }
        private void AddButtons()
        {
            Panel1.Controls.Clear();
            foreach (ButtonState buttonState in this.ButtonTexts)
            {
                Button b = new Button();
                b.EnableViewState = false;
                b.ID = buttonState.ID;
                b.Text = buttonState.Text;
                b.Command += new CommandEventHandler(b_Command);
                Panel1.Controls.Add(b);
            }
        }
        private ButtonState[] ButtonTexts
        {
            get
            {
                ButtonState[] list = ViewState["ButtonTexts"] as ButtonState[];
                if (list == null)
                    ButtonTexts = new ButtonState[0];
                return list;
            }
            set { ViewState["ButtonTexts"] = value; }
        }
        [Serializable]
        class ButtonState
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }
