    int totaltime, time;
    private async void button1_Click(object sender, EventArgs e)
    {
        totaltime = int.Parse(label1.Text);
        time = int.Parse(label1.Text);
        for (int i = totaltime; i >= 0; i--)
        {
            --time;
            label1.Text = time.ToString();
            await Task.Delay(1000);
        }
    }
