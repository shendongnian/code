    private void button4_Click(object sender, EventArgs e)
    {
        string username;
        string password;
        string CurrentUser = "";
        string CurrentPwd = "";
        bool LoginStatus = false;
        username = textBox1.Text;
        password = textBox2.Text;
        XmlDocument xmxdoc = new XmlDocument();
        xmxdoc.Load("dati.txt");
        XmlNodeList xmlnodelist = xmxdoc.GetElementsByTagName("user");
        foreach (XmlNode xn in xmlnodelist)
        {
            XmlNodeList xmlnl = xn.ChildNodes;
            foreach (XmlNode xmln in xmlnl)
            {
                if (xmln.Name == "name")
                {
                    if (xmln.InnerText == username)
                    {
                        CurrentUser = username;
                    }
                }
                if (xmln.Name == "password")
                {
                    if (xmln.InnerText == password)
                    {
                        CurrentPwd = password;
                    }
                }
            }
            if ((CurrentUser != "") & (CurrentPwd != ""))
            {
                LoginStatus = true;
            }
        }
        if (LoginStatus == true)
        {
            button1.Visible = true;
            dlt_btn.Visible = true;
            button3.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
            return;
        }
        else
        {
            MessageBox.Show("Invalid Username or Password!");
        }
    }
