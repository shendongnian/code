    private void checkWinner()
    {
        MainWindow window1 = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        object player1 = window1.AccessNamePlayer1();
        object player2 = window1.AccessNamePlayer2();
        if (scoreName1Tot > scoreName2Tot)
        {
            MessageBox.Show(player1.ToString() + " heeft gewonnen!");
        }
        else if (scoreName1Tot < scoreName2Tot)
        {
            MessageBox.Show(player2.ToString() + " heeft gewonnen!");
        }
        else if (scoreName1Tot == scoreName2Tot)
        {
            MessageBox.Show("Gelijkspel!");
        }
    }
