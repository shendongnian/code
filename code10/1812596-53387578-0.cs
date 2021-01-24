    private void frmMain_Load(object sender, EventArgs e)
    {
        IPHostEntry IPhost = Dns.GetHostByName(Dns.GetHostName());
        lblStatus.Text = "IP Address: " + IPhost.AddressList[0].ToString();
        nSockets = new ArrayList();
        Thread thdListner = new Thread(new ThreadStart(listnerThread));
        thdListner.start()
    }
