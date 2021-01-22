    Part1()
    {
      DoSomething();
      btn.Enabled = true;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
      btn1.Enabled = false;
      Part2();
    }
