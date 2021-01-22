    private delegate void SaveEmail(MailItem mailItem);
    foreach (MailItem mailItem in totalMailItems)
    {
        SaveEmail save = SaveMailItem; 
        IAsyncResult saveResult = save.BeginInvoke(mailItem, SaveCallBack, "MailItem Saved") 
        xMail = null;
    }
    private void SaveCallBack(IAsyncResult result)
    { // do stuff here if you want to... }
    private void SaveMailItem(MailItem mailItem)
    {
        MailItem xMail = mailItem;
        MessageRelevance mRel = new MessageRelevance();
        mRel = Process_MailItem(ref xMail);              
        xMail.Save();
        switch(mRel)
        {
            case MessageRelevance.Red:
                xMail.Move(redFold);
                _lvl2++;
                break;
            case MessageRelevance.Orange:
                xMail.Move(orangeFold);
                _lvl1++;
                break;
            case MessageRelevance.Blue:
                xMail.Move(blueFold);
                _nullLev++;
                break;
            case MessageRelevance.Green:
                xMail.Move(greenFold);
                _lvl0++;
                break;
        } 
    }
