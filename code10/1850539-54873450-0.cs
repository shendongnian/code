    bool buttonisclicked1 = false;
    bool buttonisclicked2 = false;
    bool buttonisclicked3 = false;
    public void button1_Click(object sender, EventArgs e)
    {
        Button clickedButton1 = (Button)sender;
        clickedButton1.Text = "X";
        bool buttonisclicked1 = true;
        Win()
    }
    public void button2_Click(object sender, EventArgs e)
    {
        Button clickedButton2 = (Button)sender;
        clickedButton2.Text = "X";
        bool buttonisclicked2 = true;
        Win()
    }
    public void button3_Click(object sender, EventArgs e)
    {
        Button clickedButton3 = (Button)sender;
        clickedButton3.Text = "X";
        bool buttonisclicked3 = True;
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
}
The reason I have put the the `Win()` in each `Click Event()` is that way it will check the conditions each time, despite the order of buttons clicked.
