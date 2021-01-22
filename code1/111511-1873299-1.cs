    private void Consume(T notif)
    {
           lock(notif.ID)
           {
            ...
           }
    }
