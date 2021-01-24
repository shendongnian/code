    class SomeClass
    {
      private StringBuilder _sb = new StringBuilder();
      private SerialPort serialPort1 
      [...]
      void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
      {
        if (e.EventType == SerialData.Chars)
           sb.Append(serialPort1.ReadExisting());
      }
    }
