    public delegate void Event(object Sender, EventType Type, object EventData);
    public event Event OnDeath;
    public event Event OnMove;
    public void TakeDamage(int a)
    {
        Health-=a;
        if(Health<1)
            OnDeath?.Invoke(this,EventType.PlayerDeath,null);
    }
    public void ThreadedMovementFunction()
    {
        while(true)
        {
            int x,y;
            (x,y) = GetMovementDirection(); 
            if(x!=0||y!=0)
                OnMove?.Invoke(this,EventType.PlayerMove,(x,y));
        }
    }
