    private void CreateMyStatusBar(string msg = "Ready")
    {
       panel1.Controls.Add(new StatusBar{ Text = msg });
    }
    private void button1_Click(object sender, EventArgs e)
    {
       CreateMyStatusBar("Test");
       CreateMyStatusBar();
    }
