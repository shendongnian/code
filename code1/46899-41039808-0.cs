    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    namespace Lambda1
    {
    public partial class Form1 : Form
    {
        System.Timers.Timer t = new System.Timers.Timer(1000);
        Int32 c = 0;
        Int32 d = 0;
        Func<Int32, Int32, Int32> y;
        
        public Form1()
        {
            
            InitializeComponent();           
            t.Elapsed += t_Elapsed;
            t.Enabled = true;
        }
        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            c = (Int32)(label1.Invoke(y = (x1, x2) => 
                  { label1.Text = (x1 + x2).ToString(); 
                                   x1++;  
                                   return x1; },  
                                   c,d));
            d++;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Enabled = false;
        }
    }
    
    }
