     private void LuckyButton_Click(object sender, EventArgs e)
        {
            Random RandomNumberGenerator = new Random();
            string newLine = Environment.NewLine;
            int Winning1 = 0;
            int Winning2 = 0;
            int Winning3 = 0;
            int randomNumber = RandomNumberGenerator.Next(10);
            int counter = 0;
            int winnerId = 0;
            int.TryParse(WinningNumber1.Text, out Winning1);
            int.TryParse(WinningNumber2.Text, out Winning2);
            int.TryParse(WinningNumber3.Text, out Winning3);
            if (Winning1 <= 0 || Winning2 <= 0 || Winning3 <= 0 ||
                Winning1 > 10 || Winning2 > 10 || Winning3 > 10)
            {
                MessageBox.Show("Invalid Number!");
                return;
            }
            while (counter < 1000)
            {
                if (Winning1 == randomNumber)
                {
                    winnerId = 1;
                    break;
                }
                else if (Winning2 == randomNumber)
                {
                    winnerId = 2;
                    break;
                }
                else if (Winning3 == randomNumber)
                {
                    winnerId = 3;
                    break;
                }
                randomNumber = RandomNumberGenerator.Next(10);
                counter++;
            }
            if(winnerId != 0)
            {
                MessageBox.Show("Number " + winnerId + " wins!");
            }
            else
            {
                MessageBox.Show("no one wins!");
            }
        }
