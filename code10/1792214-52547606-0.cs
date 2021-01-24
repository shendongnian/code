        private void Msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(Msg));
            }
            else
            {
                textBox2.Text = textBox2.Text + Environment.NewLine + " >> " + _readData;
            }
        }
