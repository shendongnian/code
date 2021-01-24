    private void timer1_Tick_1(object sender, EventArgs e)
    {
        if (...)
                    {
                        string sieg = "...";
                    {
                        richTextBox1.Text = sieg;
                    }    
                    if (...)
                    {
                        timer2.Interval = 1000;
                        timer2.Enabled = true;
                        timer2.Start();
                    }
                }
                    if (...)
                    {
                        string lose = "...";
                        richTextBox1.Text = lose;
                        if (...)
                        {
                            timer2.Interval = 10000;
                            timer2.Enabled = true;
                            timer2.Start();
                        }
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        Application.Exit();
    }
