    public string player1 { get; set; }
    public string player2 { get; set; }
    private void checkWinner()
    {
        if (scoreName1Tot == scoreName2Tot)
        {
            MessageBox.Show("Gelijkspel!");
        }
        else
        {
            string winner = (scoreName1Tot > scoreName2Tot) ? player1 : player2;
            MessageBox.Show(winner + " heeft gewonnen!");
        }
    }
