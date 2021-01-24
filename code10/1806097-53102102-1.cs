        string value;
        private void button3_Click(object sender, EventArgs e)
        {
            WaitSecondsAndExecute(10);
        }
        private async void WaitSecondsAndExecute(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                await Task.Delay(1000);
                if (value != null)
                {
                    break;
                }
            }
            
            if (value != null)
            {
                listBox2.Items.Add("good"); // if response string value != ""
            }
            else
            {
                listBox2.Items.Add("bad");
                // if response string value == "" or timeout  
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            value = "best"; // add value
        }
