    public event Action myEvent;
    public void Function1 ()
    {
        myEvent?.invoke();
    }
