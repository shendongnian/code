    // the Serial Port detection routine 
    private void testSerialPort(object obj)
    {
        if (! (obj is string) )
            return;
        string spName = obj as string;
        SerialPort sp = new SerialPort(spName);
        try
        {
            sp.Open();
        }
        catch (Exception)
        {
            // users don't want to experience this
            return;
        }
        if (sp.IsOpen)
        {
            if ( You can recieve the data you neeed)
            {
                isSerialPortValid = true;
            }
        }
        sp.Close();
    }
    // validity of serial port        
    private bool isSerialPortValid;
    
    // the callback function of button checks the serial ports
    private void btCheck(object sender, RoutedEventArgs e)
    {
        foreach (string s in SerialPort.GetPortNames())
        {
            isSpValid = false;
            Thread t = new Thread(new ParameterizedThreadStart(testSerialPort));
            t.Start(s);
            Thread.Sleep(500); // wait and trink a tee for 500 ms
            t.Abort();
            
            // check wether the port was successfully opened
            if (isSpValid)
            {
                textBlock1.Text = "Serial Port " + s + " is OK !";
            }
            else
            {
                textBlock1.Text = "Serial Port " + s + " retards !";
            }
          }
       }   
    }   
