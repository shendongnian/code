    private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Stop();
                nCount++;
                if (nCount < listBox1.Items.Count)
                {
                    label2.Text = listBox1.Items[nCount].ToString();
                }
                timer1.Start();
            }
