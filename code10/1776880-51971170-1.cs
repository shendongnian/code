    private void button3_Click(object sender, EventArgs e)
    {
        // I don't think you need this
        // var car = cars.Select(a => a);
        if (i + 1 >= 0 && i + 1 < cars.Count)
        {
            i++;
            var car = cars.ToArray()[i];
            label1.Text = car.Brand;
            label2.Text = car.Model;
            label3.Text = car.Color;
        }
    }
    private void button4_Click(object sender, EventArgs e)
    {
        if (i - 1 >= 0 && i - 1 <= cars.Count)
        {
            i--;
            var car = cars.ToArray()[i];
            label1.Text = car.Brand;
            label2.Text = car.Model;
            label3.Text = car.Color;
        }
    }
