        try
            {
                double mydoubleParam = 0;
                // Assuming textBox1.Text is Name test box
                if (double.TryParse(textBox1.Text, out mydoubleParam))
                {
                     new Exception(" Numeric value in name field");
                }
                int age = int.Parse(textBox2.Text);// Assuming Number text box
                
                MessageBox.Show("How are you today?");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Something went wrong");
            }
