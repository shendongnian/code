    string[] contents = new string[3];
        
    contents[0] = "Name: " + textBox1.Text;
    contents[1] = "College: " + textBox2.Text;
    contents[2] = "Roll: " + textBox3.Text;
     
    File.WriteAllLines(@"C:\Users\...\test.txt", string.Join(Environment.NewLine,contents), Encoding.UTF8);
