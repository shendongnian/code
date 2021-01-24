    List<string> lstIpAddress = new List<string>();
    int nCount = 0;
    private void Form1_Load(object sender, EventArgs e)
    {
       timer1.Interval = 30000;
    }
     private void button1_Click(object sender, EventArgs e)
     {
            string strIp = textBox1.Text;
            if (strIp.Length > 0)
            {
                lstIpAddress = strIp.Split(',').ToList();
                for (int nlstItem = 0; nlstItem < lstIpAddress.Count; nlstItem++)
                {
                    listBox1.Items.Add(lstIpAddress[nlstItem]);
                }
                //Pass the IP to Web Browser
                label2.Text = listBox1.Items[nCount].ToString();
                nCount++;
            }
            timer1.Start();
     }
     private void timer1_Tick(object sender, EventArgs e)
     {
            timer1.Stop();
            //Pass the IP to Web Browser
            label2.Text = listBox1.Items[nCount].ToString();
            timer1.Start();
     }
