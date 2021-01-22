    public MyBaseForm : Form
    {
        private Label lblTimer;
        public MyBaseForm()
        {
            lblTimer = new Label();
            Controls.Add(lblTimer);
        }
        public void UpdateTimerText(string text)
        {
            lblTimer.Text = text;
        }
    }
