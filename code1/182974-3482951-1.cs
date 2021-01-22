    void button1_Click(object sender, EventArgs e)
    {
        int max;
        try
        {
            // This is what you have in your click handler,
            // Int32.TryParse is a much better alternative.
            max = Convert.ToInt32(textBox1.Text);
        }
        catch
        {
            MessageBox.Show("Enter numbers", "ERROR");
            return;
        }
        progressBar1.Maximum = max;
        worker.RunWorkerAsync(max);
    }
