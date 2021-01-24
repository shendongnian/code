        private async void button1_Click(object sender, EventArgs e)
        {
            await TimeConsumingOperation();
        }
        public async Task TimeConsumingOperation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            await Task.Delay(10000);
            progressBar1.Visible = false;
        }
