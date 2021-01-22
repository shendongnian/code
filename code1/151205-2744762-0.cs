    const int PORT_OPEN_MAX_ATTEMPTS = 10;
    bool portOpened = false;
    int portOpenAttempts = 0;                     
    
                _port = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);                      
               
                while (!portOpened)
                {
                    try
                    {
                        _port.Open();
                        portOpened = true;      // Only get here if no exception
                    }
    
                    catch (UnauthorizedAccessException ex)
                    {
                        // Log, close, then try again
                        if (portOpenAttempts++ < PORT_OPEN_MAX_ATTEMPTS)
                        {                       
                            _logger.Debug("Port UnauthorizedAccessException. Attempt - " + portOpenAttempts);
                           
                            Thread.Sleep(100);
                            _port.Close();
                        }
                       
                        else
                        {
                            throw(ex);
                        }
                    }
                }
