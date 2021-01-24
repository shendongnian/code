        private HashSet<DateTimePicker> dateChanged = new HashSet<DateTimePicker>();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dateChanged.Clear();
            button1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = @" ";
            dateTimePicker2.CustomFormat = @" ";
            dateTimePicker3.CustomFormat = @" ";
        }
        private void dp_ValueChanged(object sender, EventArgs e)
        {
            var dp = (DateTimePicker) sender;
            dp.Format = DateTimePickerFormat.Short;
            dateChanged.Add(dp);
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
