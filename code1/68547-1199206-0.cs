    protected void RaiseMouseDownEvent(MouseEventArgs e)
    {
        MouseEventHandler handler = (MouseEventHandler) base.Events[mouseDownEventKey];
        if (handler != null)
        {
            handler(this, e);
        }
    }
