    public static func(CustomObject o)
    {
        if (ReadyForUpdate(o))
        {
            lock (entity)
            {
                    if (ReadyForUpdate(o))
                    {
                            PerformUpdate(entity);
                    }
            }
        }
    }
