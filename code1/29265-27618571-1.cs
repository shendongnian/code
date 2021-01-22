            double parsedValue;
            if (!double.TryParse(textBox1.Text, out parsedValue))
            {
                textBox1.Text = "";
            }
        }
