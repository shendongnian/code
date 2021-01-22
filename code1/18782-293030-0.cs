    public event MyDelegate Fire;
    public void FireEvent(string msg)
    {
        MyDelegate temp = Fire;
        if (temp != null)
            temp(msg);
    }
