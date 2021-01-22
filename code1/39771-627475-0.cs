    public bool OnPreUpdate(PreUpdateEvent evt)
    {
        string[] names = evt.Persister.PropertyNames;
        for(int index = 0; index < names.Length; index++)
        {
            // compare evt.State[index] to evt.OldState[index] and get
            // the name of the changed property from 'names'
            // (...)
        }
    }
