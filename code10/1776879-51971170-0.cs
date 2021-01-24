    private void button2_Click(object sender, EventArgs e)
    {
        i = cars.FindIndex(c => c.Brand == textBox4.Text);
        if(i >= 0)
        {
            var car = cars.ToArray()[i]; // no reason to search twice
            label1.Text = car.Brand;
            label2.Text = car.Model;
            label3.Text = car.Color;
        }
        else
        {
            MessageBox.Show("This car is not in the list");
        }
    }
