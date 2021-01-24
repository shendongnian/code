    bool IsTwoPlayerGame => return this.CheckBoxTwoPlayers.Checked;
    void OnPlayButtonPressed(object sender, EventArgs e)
    {
        // operator pressed one of the playButtons. Which button is in the sender
        if (Object.ReferenceEquals(sender, buttonRock))
           Play(Choice.Rock);
        else if (Object.ReferenceEquals(sender, buttonPaper))
           Play(Choice.Paper);
        else
           Play(Choice.Scissors);
    }
