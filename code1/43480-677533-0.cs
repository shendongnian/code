        protected void OnSomeEvent(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                ErrorMessage.Text = "your socks are the wrong colour";
                return;
            }
            // Continue processing.
        }
