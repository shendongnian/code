    void MyThread()
    {
        while(true)
        {
            // thread will wait until the semaphore is triggered once
            // there are other ways to call this which allow you to pass a timeout
            s.WaitOne();
            // after being triggered once, thread is clear to get an item from the queue
            Bucket b = null;
            // you still need to lock because more than one thread can pass the semaphore at the sam time.
            lock(B_Lock)
            {
                b = B.Pop();
            }
            b.UseBucket();
            // after you finish using the item, add it back to the queue
            // DO NOT keep the queue locked while you are using the item or no other thread will be able to get anything out of it            
            lock(B_Lock)
            {
                B.Push(b);
            }
            
            // after adding the item back to the queue, trigger the semaphore and allow
            // another thread to enter
            s.Release();
        }
    }
