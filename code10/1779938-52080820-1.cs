    delegate void TimerDelegate(bool Enable);
    private void ControlTimer(bool Enable)
    {
      timerColor.Enabled = Enable;
    }
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        MessageBox.Show("Dati Ricevuti: " + indata);
        if (indata.CompareTo("K") == 0)
        {
            Invoke((TimerDelegate)ControlTimer, true);
            btnEsito.BackColor = Color.Green;
            btnEsito.Text = "GOOD";
            // Do something
        }
        if (indata.CompareTo("O") == 0)
        {
            Invoke((TimerDelegate)ControlTimer, true);
            btnEsito.BackColor = Color.Red;
            btnEsito.Text = "NO GOOD";
        }
    }
    private void timerColor_Tick(object sender, EventArgs e)
    {
        MessageBox.Show("HERE!");
        Invoke((TimerDelegate)ControlTimer, false);
        btnEsito.BackColor = Color.White;
    }
