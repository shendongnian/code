    void camera_ReceivedFrame(object sender, StreamEventArgs e)
    {
        if(myOutputPanel.InvokeRequired)
        {
            myOutPutPanel.BeginInvoke( 
                new Camera.ReceivedFrameEventHandler(camera_ReceivedFrame), 
                sender, 
                e);
        }
        else
        {
            myOutPutPanel.Image = e.Image;
        }
    }
