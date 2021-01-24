    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            int nameI = index * 3 + 1;
            int passI = index * 3 + 2;
            string nameS;
            string passS;
            var lineCount = File.ReadLines(@"C:\accs.txt").Count();
            
            nameS = File.ReadLines(@"C:\accs.txt").ElementAt(nameI);
            textBox1.Text = nameS.ToString();
            passS = File.ReadLines(@"C:\accs.txt").ElementAt(passI);
            textBox2.Text = passS.ToString();
        }
