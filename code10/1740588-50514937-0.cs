    List<System.Windows.Forms.Timer> timers =
      new List<System.Windows.Forms.Timer>();
    List<Car> list = new List<Car>();
    private void button1_Click(object sender, EventArgs e)
    {
      Car car = new Car(50, 50, 40, 40);
      list.Add(car);
      Timer timer = new Timer();
      timer.Tick += Timer_Tick;
      timer.Interval = 100;
      timer.Tag = car;
      timer.Start();
      timers.Add(timer);
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      Car car = (Car)((sender as Timer).Tag);
      car.Move();
      pictureBox1.Invalidate();
    }
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.Clear(Color.White);
      foreach (Car car in list)
      {
        car.DrawCar(g, Color.Blue);
      }
    }
