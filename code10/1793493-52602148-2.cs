    private void Form2_Load(object sender, EventArgs e)
        {
            //if the start button isn't pressed, in 5 seconds, Form2 closes and Form1 opens
            // Don't really need this because a user won't be able to click the button before the form loads
            if (!startButtonWasClicked)
            {
                t2.Interval = 5000;
                t2.Tick += new EventHandler(OnTimerTicker);
                t2.Start();
            }
            //else start button is clicked
    
        }
