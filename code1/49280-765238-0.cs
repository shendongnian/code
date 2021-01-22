    public int GetHandle
        {
            get
            {
                if (this.InvokeRequired)
                {
                    return (int)this.Invoke((GetHandleDelegate)delegate
                    {
                        return this.Handle.ToInt32();
                    });
                }
                return this.Handle.ToInt32();
            }
        }
    private delegate int GetHandleDelegate();
