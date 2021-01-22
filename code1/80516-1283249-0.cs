    public void VerifyIfFirstTimeRun()
        {
            if (Properties.Settings.Default.FirstTimeUse == true)
            {
                //Do something here.
                //Change first time usage Bool to false
                Properties.Settings.Default.FirstTimeUse = false;
                //Save your changes, and you're done!
                Properties.Settings.Default.Save();
            }                        
        }
