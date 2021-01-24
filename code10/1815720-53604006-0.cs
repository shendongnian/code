    public MessageResult Message(InstallMessage messageType, Record record)
    {
        if (record == null)
        {
            throw new ArgumentNullException("record");
        }
    
        int ret = RemotableNativeMethods.MsiProcessMessage((int) this.Handle, (uint) messageType, (int) record.Handle);
        if (ret < 0)
        {
            throw new InstallerException();
        }
        else if (ret == (int) MessageResult.Cancel)
        {
            throw new InstallCanceledException();
        }
        return (MessageResult) ret;
    }
