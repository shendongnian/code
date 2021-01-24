    using System;
    using System.Windows.Forms;
    
    namespace TwoForms
    {
        public partial class Form1 : Form
        {
                private Timer t = new Timer();
                public static int counter = 60;
                public Form TheForm2;
                public Form1()
                {
                    InitializeComponent();
                    t.Tick += new EventHandler(Timer_Tick);
                    t.Interval = 1000;
                    t.Enabled = true;
                    t.Start();
                    this.Show(); // show Form1 just so we know it's really there
                    TheForm2 = new Form2();
                    // TheForm2.ShowDialog(); // Don't do this unless you really want a modal dialog
                    TheForm2.Show();
                    TheForm2.Visible = false; // A timer tick will later set visible true
                }
            void Timer_Tick(object sender, EventArgs e)
            {
                counter -= 1;
                if (counter == 50)
                    TheForm2.Visible = true;
                if (counter == 40)
                    MessageBox.Show("Time remaining " + counter.ToString());
            }
        }
    }
