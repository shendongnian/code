    public delegate void MyDelegate(Message msg);
    void foo_MessageReceived(Message message)
    { 
    if (IvokeRequired)
    {
       BeginInvoke(new MyDelegate(foo_MessageReceived),new object[]{message});
    }
    else
    {
      label1.Text = message.Body;
    }
    }
