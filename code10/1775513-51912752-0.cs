    string otherProgramString = "A12345";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox3.Items.Contains(otherProgramString))
                listBox4.Items.Add("Match");
            else
                listBox4.Items.Add("No match");
        }
        void SetStringFromOtherProgram(string value)
        {
            otherProgramString = value;
        }
        private void StartTimer_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
        private void EndTimer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 100;
        }
