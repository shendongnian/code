    private void ReadingThreadFunction() {
        
        try {
                var autoReset = new AutoResetEvent(false);
                autoReset.WaitOne(1);
                TRxMsg receivedMessage;
                ReadMessage(devHandle, out receivedMessage);
    
                //...do something with the message...
            }
        }
        catch {
            //... catch exception if reading failed...
        }
    }
