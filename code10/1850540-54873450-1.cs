    bool buttonisclicked1 = false;
    bool buttonisclicked2 = false;
    bool buttonisclicked3 = false;
    public void button1_Click(object sender, EventArgs e)
    {
        Button clickedButton1 = (Button)sender;
        clickedButton1.Text = "X";
        buttonisclicked1 = true;
        Win()
    }
    public void button2_Click(object sender, EventArgs e)
    {
        Button clickedButton2 = (Button)sender;
        clickedButton2.Text = "X";
        buttonisclicked2 = true;
        Win()
    }
    public void button3_Click(object sender, EventArgs e)
    {
        Button clickedButton3 = (Button)sender;
        clickedButton3.Text = "X";
        buttonisclicked3 = True;
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
You do not need to have an `If` statement to check if the `.Text` property of the button has changed, as it is set to *always* change to `'X'`. If you had other conditions and code *within* the `Click Event`s that could either change the `.Text` property to something else, then it would make sense to have an `If` statement. Otherwise- it is not necessary.
