    class SomeClass
    {
      private StringBuilder _sb = new StringBuilder();
      private SerialPort serialPort1 
      [...]
      void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
      {
        if (e.EventType == SerialData.Chars)
        {
           _sb.Append(serialPort1.ReadExisting());
        }
        else
        {
           MessageBox.Show(_sb.ToString());
           _sb.Clear();
        }
      }
    }
