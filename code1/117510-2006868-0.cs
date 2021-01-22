    private void button3_Click(object sender, EventArgs e)
    {
        string helpstring = "Help";
        string hidestring = "Hide";
        if (button3.Text == helpstring)
        {
            button3.Text = hidestring;
            Size = new System.Drawing.Size(1106, 563);
        }
        else
        {
            Size = new System.Drawing.Size(586, 563);
            button3.Text = helpstring;
        }
    }
