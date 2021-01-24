        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex1 = new Regex("^[a-zA-Z ]+$");
            Regex dat = new Regex("^(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])([0-9]{2})[-]([0-9]{5})$");
            Regex epasts = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Use a boolean to determine whether there is an error
            var valid = true;
            if (!regex1.IsMatch(textBox1.Text))
            {
                valid = false;
                label5.ForeColor = Color.Red;
                label5.Text = "Incorrectly entered name!";
            }
            else
            {
                label5.Text = "";
            }
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                valid = false;
                label5.ForeColor = Color.Red;
                label5.Text = "Name wasn't entered!";
            }
            if (!regex1.IsMatch(textBox2.Text))
            {
                valid = false;
                label6.ForeColor = Color.Red;
                label6.Text = "Surname entered incorrectly!";
            }
            else
            {
                label6.Text = "";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                valid = false;
                label6.ForeColor = Color.Red;
                label6.Text = "No surname!";
            }
            if (!dat.IsMatch(textBox3.Text))
            {
                valid = false;
                label7.ForeColor = Color.Red;
                label7.Text = "Incorrect code!";
            }
            else
            {
                label7.Text = "";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                valid = false;
                label7.ForeColor = Color.Red;
                label7.Text = "Not entered!";
            }
            if (!epasts.IsMatch(textBox4.Text))
            {
                valid = false;
                label8.ForeColor = Color.Red;
                label8.Text = "Incorrectly entered email!";
            }
            else
            {
                label8.Text = "";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                valid = false;
                label8.ForeColor = Color.Red;
                label8.Text = "Email not entered!";
            }
            // Now you can check if there is an error 
            if (valid)
            {
                // This doesn't make any sense - because the user can ONLY click ok 
                //if (MessageBox.Show("Data is being saved", "Data saving", MessageBoxButtons.OK) == DialogResult.OK)
                // I think you maybe meant something like this? 
                if (MessageBox.Show("Data is being saved", "Data saving", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // And here - I'm assuming you would save the data somewhere and then clear the textboxes? 
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please correct the errors and try again");
            }
        }
