        private HashSet<DateTimePicker> dateChanged = new HashSet<DateTimePicker>();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dateChanged.Clear();
            button1.Enabled = false;
        }
        private void dp_ValueChanged(object sender, EventArgs e)
        {
            dateChanged.Add((DateTimePicker) sender);
            SetEnabledness();
        }
        private void SetEnabledness()
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && dateChanged.Count == 3;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetEnabledness();
        }
