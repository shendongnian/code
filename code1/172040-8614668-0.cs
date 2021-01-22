            string myString = textBox1.Text.Trim();
            if (Regex.IsMatch(myString, regular))
            {
                MessageBox.Show("It is valide url  " + myString);
            }
            else if (Regex.IsMatch(myString, regular123))
            {
                MessageBox.Show("Valide url with www. " + myString);
            }
            else 
            {
                MessageBox.Show("InValide URL  " + myString);
            }
