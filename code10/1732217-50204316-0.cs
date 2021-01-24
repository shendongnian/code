      private void Form1_Load(object sender, EventArgs e)
    {
     Process[] prs = (Process.GetProcesses());
               
                 foreach (Process pr in prs)
                 {
                 
                    listBox1.Items.Add(Convert.ToString(pr.ProcessName));
                 }
    }
