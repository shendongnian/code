     private static ObservableCollection<string> ReadValues = null;
     public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
     {
         SerialPort sp = (SerialPort)sender;
         string indata = sp.ReadLine();
         ReadValues.Add(indata);
     }
