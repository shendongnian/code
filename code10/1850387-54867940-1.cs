    void Play(Choice thisPlayersChoice)
    {
        var otherPlayersCoice = this.FetchOtherPlayersChoice();
        var winner = this.CheckWinner(thisPlayersChoice, otherPlayersChoice);
        DislayWinner(thisPlayersChoice, otherPlayersChoice, winner);
    }
    Choice FetchOtherPlayersChoice()
    {
        return this.IsTwoPlayerGame ??
           this.OtherPlayersChoice() :
           this.ComputerChoice();
    }
    void Display(Choice choice1, Choice choice2, Winner winner)
    {
        string displayText = this.IsTwoPlayerGame ?
            $"Player 1 chose {choice1}, Player 2 chose {choice2}. Winner: {winner}" :
            $"Player 1 chose {choice1}, Computer chose {choice2}. Winner: {winner}";
        MessageBox.Show(displayText);
    }
