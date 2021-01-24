    private void Form2_Load(object sender, EventArgs e)
    {
        Hector.Framework.Utils.Peripherals.Mouse.MoveToPoint(300, 0); //Move the cursor to Top
    }
    //Then use timer to move the cursor
    int a = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        Hector.Framework.Utils.Peripherals.Mouse.MoveToPoint(300, a += 1);
    }
    if(MouseLeftButton)
    {
       timer1.Start(); //timer is initialized
    }
