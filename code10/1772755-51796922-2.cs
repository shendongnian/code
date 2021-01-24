    #region ThisIsCalledEvent
            private Action m_ThisIsCalledEvent;
            public Action ThisIsCalledEvent
            {
                get
                {
                    return m_ThisIsCalledEvent;
                }
                set
                {
                    if (m_ThisIsCalledEvent != value)
                    {
                        m_ThisIsCalledEvent = value;
                        OnPropertyChanged(nameof(ThisIsCalledEvent));
                    }
                }
            }
    #endregion
