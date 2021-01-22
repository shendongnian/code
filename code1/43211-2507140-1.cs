    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                while (keepReading)
                {
                    backgroundWorker1.ReportProgress(0, serialPort1.ReadLine());
                    //backgroundWorker1.ReportProgress(0, sentence.Split(','));
                    // split_gps_data();
                }
            }
        }
    }
