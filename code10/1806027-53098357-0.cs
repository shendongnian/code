        private async void button1_Click(object sender, EventArgs e)
        {            
            await test();
        }
        protected async Task test()
        {            
            label1.Text = "";
            for (int i=0;i<10;i++)
            {
                label1.Text += i;
                await Task.Delay(TimeSpan.FromMilliseconds(500)); //Thread.Sleep(500);
            }
         }
