    private bool gameIsOver = false; //boolean to track if the game is over or not
    private void CheckForWinner()
    {
        bool there_is_a_winner = false;
    
        //[RemovedCode] - Evaluation of your buttons...
    
        if (there_is_a_winner)
        {
            gameIsOver = true;
            //[RemovedCode] - winning code...
        }
        else
        {
            if(tic_counter == 9)
            {
                gameIsOver = true;
                //[RemovedCode] - losing code...
            }
        }
    }
