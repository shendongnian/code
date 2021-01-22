    bool locked = false;
    if (condition) {
        Monitor.Enter(lockObject);
        locked = true;
    }
    try {
        // possibly critical section
    }
    finally {
        if (locked) Monitor.Exit(lockObject);
    }
