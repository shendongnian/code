    class MemberClass
    {
            private EventHandler _event;
    
            public event EventHandler Event
            {
                add
                {
                    if( /* delegate not already added */ )
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
