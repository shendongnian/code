        private EventHandler ButtonClick;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            m_Button = new Button{Text = "Do something"};
            m_Button.Click += ButtonClick;
            ButtonClick += button_Click;
            Controls.Add(m_Button);
        }
        private void MakeButtonDoStuff()
        {
            ButtonClick.Invoke(this, new EventArgs());
        }
        private void button_Click(object sender, EventArgs e)
        {
        }
