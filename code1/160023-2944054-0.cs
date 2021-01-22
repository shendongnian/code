    static public bool CheckWinner(Button[] myControls)
    {
        //bolean statement to check for the winner 
        bool gameOver = false;
        bool foundEmpty = false;
        for (int i = 0; i < 8; i++)
        {
            int a = Winners[i, 0];
            int b = Winners[i, 1];
            int c = Winners[i, 2];
            Button b1 = myControls[a], b2 = myControls[b], b3 = myControls[c];
            if (b1.Text == "" || b2.Text == "" || b3.Text == "")
            {
                foundEmpty = true;
                continue;
            }
            if (b1.Text == b2.Text && b2.Text == b3.Text)
            {
                b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                b1.Font = b2.Font = b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                gameOver = true;
                xWinnerForm xWinnerForm = new xWinnerForm();
                xWinnerForm.ShowDialog(); //only works with show not showDialog method gets overloaded  (b1.Text + " is the Winner"); to get around this I added and image showing the last player
            }
        }
        if (!gameOver && !foundEmpty)
        {
           // must be a draw
           gameOver = true;
        }
        return gameOver;
    }
