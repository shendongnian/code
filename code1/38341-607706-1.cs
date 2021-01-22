    public delegate void MyDelegate(Message msg);
    void foo_MessageReceived(Message message)
    { 
       if (InvokeRequired)
       {
          BeginInvoke(new MyDelegate(foo_MessageReceived),new object[]{message});
       }
       else
       {
          label1.Text = message.Body;
       }
    }
