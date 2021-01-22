    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace DemoWindowApp
    {
        public partial class frmDemo : Form
        {
            public frmDemo()
            {
                InitializeComponent();
            }
    
            private void btnCallMeLater_Click(object sender, EventArgs e)
            {
                MethodTimer hide = new MethodTimer(hideButton);
                MethodTimer show = new MethodTimer(showButton);
    
                hide.Interval = 1000;
                show.Interval = 5000;
    
                hide.Tick += new EventHandler(t_Tick);
                show.Tick += new EventHandler(t_Tick);
    
                hide.Start(); show.Start();
            }
    
            private void hideButton()
            {
                this.btnCallMeLater.Visible = false;
            }
    
            private void showButton()
            {
                this.btnCallMeLater.Visible = true;
            }
    
            private void t_Tick(object sender, EventArgs e)
            {
                MethodTimer t = (MethodTimer)sender;
    
                t.Stop();
                t.Method.Invoke();
            }
        }
    
        internal class MethodTimer:Timer
        {
            public readonly MethodInvoker Method;
            public MethodTimer(MethodInvoker method)
            {
                Method = method;
            }
        }
    }
