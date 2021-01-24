    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            Mutex checking = new Mutex(false);
            AutoResetEvent are = new AutoResetEvent(false);
            //You could create just one handler, but this is to show what you need to link to
            private void Form1_MouseLeave(object sender, EventArgs e)
            {
                StartWaitingForClickFromOutside();
            }
    
            private void Form1_Leave(object sender, EventArgs e)
            {
                StartWaitingForClickFromOutside();
            }
    
            private void Form1_Deactivate(object sender, EventArgs e)
            {
                StartWaitingForClickFromOutside();
            }
    
            private void StartWaitingForClickFromOutside()
            {
                if (checking.WaitOne(10))
                {
                    var ctx = new SynchronizationContext();
                    are.Reset();
    
                    Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            if (are.WaitOne(1))
                            {
                                break;
                            }
                            if (MouseButtons == MouseButtons.Left)
                            {
                                ctx.Send(CLickFromOutside, null);
                                //you might need to put in a delay here and not break depending on what you want to accomplish
                                break;
                            }
                        }
    
                        checking.ReleaseMutex();
                    });
                }
            }
    
            private void CLickFromOutside(object state)
            {
                MessageBox.Show("Clicked from outside of the window");
            }
            
    
            private void Form1_MouseEnter(object sender, EventArgs e)
            {
                are.Set();
            }
    
            private void Form1_Activated(object sender, EventArgs e)
            {
                are.Set();
            }
    
            private void Form1_Enter(object sender, EventArgs e)
            {
                are.Set();
            }
    
            private void Form1_VisibleChanged(object sender, EventArgs e)
            {
                if (this.Visible == true)
                {
                    are.Set();
                }
                else
                {
                    StartWaitingForClickFromOutside();
                }
            }
        }
    }
