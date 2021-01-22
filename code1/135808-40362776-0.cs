    private static void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        if(!String.IsEmptyOrNull( indata)) 
        {
            AddProductToCart(indata);
        }
    }
