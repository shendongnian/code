            int a, b, c;
            if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
            {
                c = a + b;
                textBox3.Text = c.ToString();
                myNumberRepository.Add(c); //Assuming you already have a way to write to the DB;
            }
