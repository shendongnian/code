     bool buttonisclicked1 = false;
    bool buttonisclicked2 = false;
    bool buttonisclicked3 = false;
    public void button1_Click(object sender, EventArgs e)
    {
        Button clickedButton1 = (Button)sender;
        clickedButton1.Text = "X";
        if (clickedButton1.Text == "X")
        {
            buttonisclicked1 = true;
        }
        Win()
    }
    public void button2_Click(object sender, EventArgs e)
    {
        Button clickedButton2 = (Button)sender;
        clickedButton2.Text = "X";
        if (clickedButton2.Text == "X")
        {
            buttonisclicked2 = true;
        }
        Win()
    }
    public void button3_Click(object sender, EventArgs e)
    {
        Button clickedButton3 = (Button)sender;
        clickedButton3.Text = "X";
        if (clickedButton3.Text == "X")
        {
            buttonisclicked3 = true;
        }
        Win()
    }
            public void Win()
    {
        if (buttonisclicked1 && buttonisclicked2 && buttonisclicked3 == true)
        {
            Console.WriteLine("You won");
            MessageBox.Show("You won!");
        }
    }
