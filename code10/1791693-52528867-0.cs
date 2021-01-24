    public async Task<ObexListenerContext> GetContext(int timeout)
    {
        var task = Task.Run(() =>
        {
            ObexListener obexListener = new ObexListener(ObexTransport.Bluetooth);
            return obexListener.GetContext();
        });
            
        if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
        {
            return task.Result;
        }
        else
        {
            throw new TimeoutException();
        }
    }
