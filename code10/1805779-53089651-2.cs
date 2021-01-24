    Random rnd = new Random();
    private void timer2_Tick(object sender, EventArgs e)
        {
            int num = rnd.Next(1, listBox2.Items.Count);
            label1.Text = num.ToString();
            if (label3.Text == "10")
            {
                listBox1.Items.Add(label1.Text);
                listBox2.Items.Remove(label1.Text); //this line of code isnt working. It doesnt delete anything.
            }
        }
