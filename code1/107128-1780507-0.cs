        public CustomControl1()
        {
            //Content = "Initial1";
        }
        protected override void OnInitialized(EventArgs e)
        {
            Content = "Initial2";
            var check = Content; // after this  check == "Initial_2"
        }
