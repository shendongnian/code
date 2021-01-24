    private int CountDown = 100;
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 form2 = new Form2(this.[The Counter Label]);
        form2.Show();
        this.timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        this.[The Counter Label].Text = CountDown.ToString();
        if (CountDown == 0)
            this.timer1.Enabled = false;
        CountDown -= 1;
    }
