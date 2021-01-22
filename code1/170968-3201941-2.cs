        private void MessageEventHandler(object sender, MessageBoxEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { MessageBox.Show(e.Message); });
            }
            else
            {
                MessageBox.Show(e.Message);
            }
        }
