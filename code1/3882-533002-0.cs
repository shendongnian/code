        public form1()
        {
           Initialize Component();
    
           this.Resize += new EventHanlder(form1_Resize);
        } 
    
        private void form1_Resize(object sender, EventArgs e)
        {
           if (this.WindowState == FormWindowState.Minimized && minimizeToTrayToolStripMenuItem.Checked == true)
           {
                 NotificationIcon1.Visible = true;
                 NotificationIcon1.BalloonTipText = "Tool Tip Text"
                 NotificationIcon1.ShowBalloonTip(2);  //show balloon tip for 2 seconds
                 NotificationIcon1.Text = "Balloon Text that shows when minimized to tray for 2 seconds";
                 this.WindowState = FormWindowState.Minimized;
                 this.ShowInTaskbar = false;
           }
        }
