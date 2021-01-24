        private void login_Click(object sender, EventArgs e)
        {
            OnLoginClicked(EventArgs.Empty);
        }
        protected virtual void OnLoginClicked(EventArgs e)
        {
            EventHandler handler = LoginClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
