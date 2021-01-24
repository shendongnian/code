    public event Action myEvent = delegate {};
    public void Function1 ()
    {
        myEvent.invoke();
    }
