    private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        sum = listBox1.Items
              .OfType<string>()
              .Select(s => Convert.ToInt32(s.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]))
              .Sum();
    }
