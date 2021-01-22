    // Declare Click Counter Global
    
    private int clickCounter = 0;
    
    // On Button Click Event
    Random r = new Random();
    
    if(clickCounter == 0)
    {
    textBox1.Text = Convert.ToInt32(r.Next(1,49));
    clickCounter++;
    }
    
    if(clickCounter == 1)
    {
    textBox2.Text = Convert.ToInt32(r.Next(1,49));
    clickCounter++;
    }
    
    if(clickCounter == 2)
    {
    textBox3.Text = Convert.ToInt32(r.Next(1,49));
    clickCounter++;
    }
    
