    using System.Windows.Forms;
    
    Timer t = new Timer();
    t.Interval = 1000;
    t.Tick += new EventHandler(timer_Tick);
    t.Start();
    
    void timer_Tick(object sender, EventArgs e)
    {
          Invoke((MethodInvoker)(() => {
              // your code here
          }));
    }
