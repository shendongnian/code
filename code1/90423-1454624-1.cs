    public void OnNewMessage(AMessage msg)
    {
        Form convoWindow = FindConvoWindow(msg.Sender);
        if (Form.ActiveForm == convoWindow)
        {
            // update the conversation text
        }
        else
        {
            convoWindow.Flash();
        }
    }
