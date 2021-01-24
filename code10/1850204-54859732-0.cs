        try
                {
                    string name = textBox1.Text;
                    int age = int.Parse(textBox2.Text);               
                    MessageBox.Show("How are you today?");
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message); // Input is not in correct format
                }
