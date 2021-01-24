        private async void button1_Click(object sender, EventArgs e)
        {
            await TimeConsumingOperation();
        }
        public async Task TimeConsumingOperation()
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(200);
                progressBar1.Value++;
            }
            progressBar1.Visible = false;
        }
