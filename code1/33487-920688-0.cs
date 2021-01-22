    private Object t_lock;
    private Semaphore sema_NotEmpty;
    private Semaphore sema_NotFull;
    private T[] buf;
    private int getFromIndex;
    private int putToIndex;
    private int size;
    private int numItems;
    public BlockingBuffer(int Capacity)
    {
        if (Capacity <= 0)
            throw new ArgumentOutOfRangeException("Capacity must be larger than 0");
        t_lock = new Object();
        buf = new T[Capacity];
        sema_NotEmpty = new Semaphore(0, Capacity);
        sema_NotFull = new Semaphore(Capacity, Capacity);
        getFromIndex = 0;
        putToIndex = 0;
        size = Capacity;
        numItems = 0;
    }
    public void put(T item)
    {
        sema_NotFull.WaitOne();
        lock (t_lock)
        {
            while (numItems == size)
            {
                Monitor.Pulse(t_lock);
                Monitor.Wait(t_lock);
            }
            buf[putToIndex++] = item;
            if (putToIndex == size)
                putToIndex = 0;
            numItems++;
            Monitor.Pulse(t_lock);
        }
        sema_NotEmpty.Release();
    }
    public T take()
    {
        T item;
        sema_NotEmpty.WaitOne();
        lock (t_lock)
        {
            while (numItems == 0)
            {
                Monitor.Pulse(t_lock);
                Monitor.Wait(t_lock);
            }
            item = buf[getFromIndex++];
            if (getFromIndex == size)
                getFromIndex = 0;
            numItems--;
            Monitor.Pulse(t_lock);
        }
        sema_NotFull.Release();
        return item;
    }
}
