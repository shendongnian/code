    async void PASECVGet(object sender, EventArgs e) //Ugh, async void, but events!
    {
        if (!SCP.IsOpen) {
            MessageBox.Show("Open the Serial Port");
        } else {
            dataout = "get pase cv";
            await Task.Delay(100);
            SCP.Write(dataout + "\r");
            blGetPASECV = true;
        }
    }
