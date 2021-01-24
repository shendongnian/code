    public List<User> Users 
    {
        get
        {
            userLock.EnterReadLock()
            try { return users; }  // DON'T DO THIS!
            finally { userLock.ExitReadLock(); }
        }
    } 
If you really need a timeout, you have to check if the lock was actually acquired, but then you have to handle the cases when the lock could not be acquired in time... so I doubt that this would be a good solution for your case. E.g.:
    public List<User> Users 
    {
        get
        {
            if(userLock.TryEnterReadLock(timeout))
            {
                try { return users; } // DON'T DO THIS!
                finally { userLock.ExitReadLock(); }
            }
            else throw new Exception("Could not acquire lock");
        }
    } 
Another critical problem that I see is when simply returning the users-list under lock, the lock is rather useless, because the activity on the user-list is done in the method that is calling the Users property, but then the lock is already exited... Also, the list could be used for writing instead of reading, so a readlock might not be correct.
One solution is returning a copy of the elements from the list:
    public User[] Users 
    {
        get
        {
            userLock.EnterReadLock()
            try { return users.ToArray(); }
            finally { userLock.ExitReadLock(); }
        }
    } 
Finally Hans Passant mentions a valid point in his comment that creating the instance is not thread safe. Either use `Lazy<T>` like proposed or use a lock.
