    private async void StreamSocketListener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
    {
        string request;
        using(var streamReader = new StreamReader(args.Socket.InputStream.AsStreamForRead()))
        {
            request = await streamReader.ReadLineAsync();
        }
        
        var setVisibility = request.Length > 0;
    
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => 
        {
           this.txtBlk_Events.Text = request;
           if ( setVisibility )
           {
              btnSend.Visibility = Visibility.Visible;
           }
        });              
    }
