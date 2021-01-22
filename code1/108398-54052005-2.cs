       IpcClientServer ipcClientServer = new IpcClientServer();
       ipcClientServer.CreateServer("localhost", 9090);
    
       IpcClientServer.RemoteMessage.MessageReceived += IpcClientServer_MessageReceived;
    </code>
    </pre>
The event listener:
    private void IpcClientServer_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(delegate { textBox2.Text += e.Message + 
            Environment.NewLine; }));
        }
        else
        {
            textBox2.Text += e.Message + Environment.NewLine;
        }
    }
