    using (var fs = new FileStream("Uye.txt", FileMode.Create))
       using (var sw = new StreamWriter(fs))
       {
          sw.WriteLine($"{textBox1.Text},{textBox2.Text},{textBox3.Text}");
       }
    // or
    // note that disposing sw in the single using will dispose the file stream 
    using (var sw = new StreamWriter(new FileStream("Uye.txt", FileMode.Create)))
    {
       sw.WriteLine($"{textBox1.Text},{textBox2.Text},{textBox3.Text}");
    }
   
