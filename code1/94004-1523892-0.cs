    private void button2_Click(object sender, EventArgs e)
            {
                Thread thread = new Thread(UpdateProcess);
                thread.Start();
            }
    
            private void SetLabelText(string val)
            {
                label1.Text = val;
            }
            delegate void m_SetLabel(string val);
    
            private void UpdateProcess()
            {
                int i = 0;
    
                while (true)
                {
                    if (label1.InvokeRequired)
                    {
                        m_SetLabel setLabel = SetLabelText;
                        Invoke(setLabel, i.ToString());
                    }
                    else
                        label1.Text = i.ToString();
                    i++;
                    Thread.Sleep(500);
                }
            }
