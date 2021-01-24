        namespace SendKeys
    {
        using System;
        using System.Linq;
        using System.Windows.Forms;
    
    
        using SendKeys = System.Windows.Forms.SendKeys;
        public sealed partial class Form1 : Form
        {
            private bool _deleting = false;
            private DateTime _startTime;
            public Form1()
            {
                InitializeComponent();
            }
    
            private static Random random = new Random();
            public static string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }
    
            private void timer2_Tick(object sender, EventArgs e)
            {
                SendKeys.Send(_deleting ? "{BACKSPACE}" : RandomString(1));
                _deleting = !_deleting;
                if (DateTime.Now - _startTime >= TimeSpan.FromMinutes(30))
                    timer2.Enabled = false;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer2.Interval = 2000;
                timer2.Enabled = true;
                _startTime = DateTime.Now;
            }
        }
    }
