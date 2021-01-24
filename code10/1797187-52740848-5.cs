    private void button_click(object sender, MouseEventArgs e)
    {
         ExecuteButtonCode(sender);
    }
    private void ExecuteButtonCode(object sender)
    {
        var oldTurn = turn;
        Button b = (Button)sender;
        if (turn)
            b.Text = "X";
        else
            b.Text = "O";
    
        turn = !turn;
        b.Enabled = false;
        tic_counter++;
        CheckForWinner();
        if (oldTurn)
            computer_make_move();
    }
