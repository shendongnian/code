    int samplingRate;
    bool ok = int.TryParse(tblSamplingRate.Text, out samplingRate);
    if (!ok)
    {
        MessageBox.Show("Please enter a valid number.");
        improperDataEntry = 1;
        return;
    }
    if(samplingRate == 0)
    {
        MessageBox.Show("Sampling Rate Cannot Equal Zero");
        improperDataEntry = 1;
        return;
    }
