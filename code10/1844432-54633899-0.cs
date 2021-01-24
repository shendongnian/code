    private void button1_Click(object sender, EventArgs e)
        {
           string dir = @"C:\Knjigovodstvo\Firme\"+textBox1.Text+"";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(Path.Combine(dir, "Podaci.txt"), textBox1.Text);
            StreamWriter sw = new StreamWriter("Podaci.txt");
           sw.WriteLine("" + textBox1.Text + "");
           sw.Close();
       }
