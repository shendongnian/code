    private void button_click(object sender, MouseEventArgs e)
    {
        var oldTurn = turn;
        Button b = (Button)sender;
        if (turn)
            b.Text = "X";
        else
            b.Text = "O";
    
        turn = !turn;
        //try to remove this line since it will block PerformClick in computer_make_move()
        //don't know for sure if that is the button that gets "clicked" in Computer
        //b.Enabled = false;
        tic_counter++;
        CheckForWinner();
        if (!oldTurn)
            computer_make_move();
    }
