    namespace Me.MyDemo
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                MyApplicationContext ac = new MyApplicationContext();
                Application.Run(ac);
            }
    
            class MyApplicationContext : ApplicationContext
            {
                string _text = "";
    
                public MyApplicationContext()
                {
                    Form1 f1 = new Form1();
                    f1.FormClosing += new FormClosingEventHandler(f1_FormClosing);
                    f1.FormClosed += new FormClosedEventHandler(f1_FormClosed);
                    Console.WriteLine("I am here. Showing form in 1 second...");
                    Thread.Sleep(1000);
                    f1.Show();
                }
    
                void f1_FormClosing(object sender, FormClosingEventArgs e)
                {
                    _text = (sender as Form1).textBox1.Text;
                }
    
                void f1_FormClosed(object sender, FormClosedEventArgs e)
                {
                    Console.WriteLine("You wrote: " + _text);
                    Console.WriteLine("I will go away in 2 seconds...");
                    Thread.Sleep(2000);
                    ExitThread();
                }
            }
        }
    }
