            private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                int qty = int.Parse(textBox1.Text);
                double price = double.Parse(textBox2.Text);
                double totalPrice = qty * price;
                textBox3.Text = totalPrice.ToString();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double bTotal = double.Parse(textBox3.Text);
            if (String.IsNullOrEmpty(textBox4.Text)) textBox4.Text = "100.00";
            double gTotal = double.Parse(textBox4.Text);
            gTotal += bTotal;
            textBox4.Clear();
            textBox4.Text = gTotal.ToString();
        }
