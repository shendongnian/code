    private void transmit_Load(object sender, EventArgs e)
    {
        serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); // now it only gets called once
        // ... other existing code ...
    }
    private void btnConnect_Click(object sender, EventArgs e)
    {
        try
        {
            serialPort1.PortName = cBoxPort.Text;
            serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
            serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBit.Text);
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParity.Text);
            // serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);  // remove this line
            serialPort1.Open();
            txtReceive.AppendText("Connected\n");   
            btnConnect.Enabled = false;             
            btnClose.Enabled = true;
            btnSend.Enabled = true;
        }
        catch (Exception ex)
        {
            return;
        }
    }
