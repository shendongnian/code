    private void GameTimer(object sender, EventArgs e)
    {
        //Don't change the position of the player but a copy one, playerClone!
        Rectangle playerClone = player.Bounds; 
        playerClone.Y += jumpspeed;
        if (jump && force < 0)
        {
            jump = false;
        }
        if (left)
        {
            playerClone.X -= 5;
        }
        if (right)
        {
            playerClone.X += 5;
        }
        if (jump)
        {
            jumpspeed = -12;
            force -= 1;
        }
        else
        {
            jumpspeed = 12;
        }
        foreach (Control x in this.Controls)
        {
            if (x is PictureBox && x.Tag == "platform")
            {
                if (playerClone.IntersectsWith(x.Bounds) && !jump)
                {
                    force = 8;
                    playerClone.Y = x.Top - playerClone.Height;
                }
            }
            if (x is PictureBox && x.Tag == "coin")
            {
                if (playerClone.IntersectsWith(x.Bounds) && !jump)
                {
                    this.Controls.Remove(x); //will remove current touched coin :)
                    AddPoints(5); // each coin taken, will increase the score with 5 points!
                }
            }
            if (x is PictureBox && x.Tag == "bigCoin")
            {
                if (playerClone.IntersectsWith(x.Bounds) && !jump)
                {
                    this.Controls.Remove(x); //will remove current touched coin :)
                    AddPoints(15); ; // each coin taken, will increase the score with 15 points!
                }
            }
            this.scoreLabel.Text = "score: " + score;
        }
        if (playerClone.IntersectsWith(door.Bounds))
        {
            timer1.Stop();
            sp.Stop();
            MessageBox.Show("Congratulations! YOU WON THE GAME! + \n With a total score of: " + score + "\n Exit the game with escape (2x)");
            return;
        }
        if (playerClone.IntersectsWith(panel1.Bounds))
        {
            timer1.Stop();
            sp.Stop();
            MessageBox.Show("YOU DIED, GAME OVER! :c");
            return;
        }
        //And now set the player position
        player.Bounds = playerClone;
    }
