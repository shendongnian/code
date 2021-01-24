    private void sendbyenter(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
           string message = Observable.MsgToSend;
        try
        {
            Observable.mychatroom.sendMessage(message);
            Observable.Messages.Add(message);
            Observable.MsgToSend = "";
        }
    }
