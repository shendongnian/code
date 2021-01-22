     private Thread thd;
     private void Form1_Load(object sender, EventArgs e)
     {            
         thd = new Thread(new ThreadStart(GetHandle));
         thd.Start();
         this.Opacity = 0;
         this.Size = new Size(0, 0);
         this.Location = new Point(-100, -100);
         this.Visible = false;
     }
     private void GetHandle()
     {
         Process[] process1 = Process.GetProcessesByName("WindowsFormsApplication12.vshost");
         process1[0].WaitForInputIdle();
         IntPtr pt = process1[0].MainWindowHandle;
         MessageBox.Show(pt.ToString());
     }
