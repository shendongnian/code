    private void data_INPUT(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string data = serialPort.ReadLine();
        string[] tokens = data.Split(':');
        if (tokens[0] == "$SENSOR")
        {
            SetSensorValue(tokens[1]);
        }
    }
    delegate void SetSensorValueDelegate(string value);
    private void SetSensorValue(string value)
    {
        if (label_sensorValue.InvokeRequired)
        {
            SetSensorValueDelegate del = new SetSensorValueDelegate(SetSensorValue);
            label_sensorValue.Invoke(del, new object[] {value});
        }
        else
        {
            label_sensorValue.Text = value;
        }
    }
