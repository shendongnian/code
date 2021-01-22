    class MemberClass
    {
            private EventHandler _event;
    
            public event EventHandler Event
            {
                add
                {
                    if( /* handler not already added */ )
                    {
                        _event+= value;
                    }
                }
                remove
                {
                    _event-= value;
                }
            }
    }
