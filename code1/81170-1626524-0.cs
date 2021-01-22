        protected void Page_Load(object sender, EventArgs e)
        {
            String msg = "A message to count";
            if (msg.Length % 2 == 0)
            {
                // Enable the Even Button
                EvenButton.Visible = true;
            }
            else
            {
                OddButton.Visible = true;
            }
        }
