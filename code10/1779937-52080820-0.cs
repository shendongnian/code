    delegate void TimerDelegate(bool Enable);
    private void ControlTimer(bool Enable)
    {
      timerColor.Enabled = Enable;
    }
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        TimerDelegate d = ControlTimer;
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        MessageBox.Show("Dati Ricevuti: " + indata);
        if (indata.CompareTo("K") == 0)
        {
            Invoke(d, true);
            btnEsito.BackColor = Color.Green;
            btnEsito.Text = "GOOD";
            // Do something
        }
        if (indata.CompareTo("O") == 0)
        {
            Invoke(d, true);
            btnEsito.BackColor = Color.Red;
            btnEsito.Text = "NO GOOD";
        }
    }
    private void timerColor_Tick(object sender, EventArgs e)
    {
        TimerDelegate d = ControlTimer;
        MessageBox.Show("HERE!");
        Invoke(d, false);
        btnEsito.BackColor = Color.White;
    }
