        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Stimulus stimulus = ( Stimulus)e.UserState;
            if(e.ProgressPercentage==1)
                stimulus.perbaharuiStimulus("+");
            if (e.ProgressPercentage == 2)
                stimulus.perbaharuiStimulus("MAJU");
            if (e.ProgressPercentage == 3)
                stimulus.perbaharuiStimulus("");
           
            stimulus.Show();
        }
