            Int32 int1;
            Int32 int2;
            Int32 intsum;
            int1 = Int32.Parse(textBox1.Text);
            int2 = Int32.Parse(textBox2.Text);
            //intsum = Int32.Parse(label1.Text);
            intsum = int1 + int2;
            label1.Text = intsum.ToString("n1");
