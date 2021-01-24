    private void StatusBtn_Click(object sender, EventArgs e)
        {
            string StatusInfoToshow = "?S\r";
            string commForMeter = string.Format(StatusInfoToshow);
            try
            {
                if (statusofMeter.serialPortForApp.IsOpen)
                {
                    lineReadCounter = 0;
                    statusofMeter.serialPortForApp.Write(commForMeter);
                }
            }
            catch (Exception)
            {
                statusofMeter.ShowDataInScreenTxtb.Text = "TimeOUT Exception";
            }
        }
