    private void button4_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("dati.txt");
        bool found = false;
        foreach (XmlNode node in doc.SelectNodes("//user"))
        {
            String User = node.SelectSingleNode("name").InnerText;
            String Pass = node.SelectSingleNode("password").InnerText;
            if (User == textBox1.Text && Pass == textBox2.Text)
            {
                found = true;
                break;
        }
        if (found)
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
