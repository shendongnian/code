    private void button2_Click(object sender, EventArgs e)
    {
        string helpstring = "Help";
        string hidestring = "Hide";
        if (button3.Text == helpstring)
        {
            button3.Text = hidestring;
            Size = new System.Drawing.Size(1106, 563);
        }
        else if (button3.Text == "Hide") //this is where you should put an else
        {
            Size = new System.Drawing.Size(586, 563);
            button3.Text = helpstring;
        }
    }
