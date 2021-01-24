    private void cardsChangingTimer_Tick(object sender, EventArgs e)
    {
        int chosenImage = rnd.Next(1, 17);
        int chosenCard = rnd.Next(0, 4);
        /// ... Rest of the code goes here
                break;
            }
        }
        if (gameEnded)
        {
            //Get a reference to the timer and stop it.
            var timer = (Timer)sender;
            timer.Stop();
            DialogResult dialog = MessageBox.Show("All 4 cards were turned over...");
            if (dialog == DialogResult.OK)
            {
                card1Pic.Image = Image.FromFile("..\\..\\17.png");
                card2Pic.Image = Image.FromFile("..\\..\\17.png");
                card3Pic.Image = Image.FromFile("..\\..\\17.png");
                card4Pic.Image = Image.FromFile("..\\..\\17.png");
            }
            gameEnded = false;
            for(int i = 0; i < bucketArr.Length; i++)
                bucketArr[i] = 0;
            //start the timer here after everything has been re-initialized.
            timer.Start();
        }
    }
