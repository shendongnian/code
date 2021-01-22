    private void button1_Click(object sender, EventArgs e)
    {
        TimeSpan timespan;
        timespan = dateTimePicker2.Value - dateTimePicker1.Value;
        int timeDifference = timespan.Days;
        MessageBox.Show(timeDifference.ToString());
    }
