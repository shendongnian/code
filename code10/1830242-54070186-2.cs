        Random randomGen = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            var i = randomGen.Next(0, soop.Count);
            label1.Text = soop[i].RollNumber;
           
            counter++;
            if (counter == 200)
            {
                timer1.Stop();
                pictureBox5.Visible = false;
                counter = 0;
            }
        }
