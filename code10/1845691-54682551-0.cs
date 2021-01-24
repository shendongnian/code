        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Task.Run(() => {
                int i = 0;
                while (i < 5)
                {
                    i += 1;
                    System.Threading.Thread.Sleep(1000);
                    label1.Invoke((MethodInvoker) delegate {
                        label1.Text += "a";
                    });
                    
                }
                button1.Invoke((MethodInvoker) delegate {
                    MessageBox.Show("done");
                    button1.Enabled = true;
                });             
            });
        }
