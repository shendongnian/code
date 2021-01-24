    try {
            string name = textBox1.Text;
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(name)) {
                throws new FormatException();
            }
            int age = int.Parse(textBox2.Text);
            MessageBox.Show("How are you today?");
        }
        catch (FormatException) {
           MessageBox.Show("Something went wrong");
        }
