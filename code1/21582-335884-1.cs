    public class IdleNotifierTimerImplementation : IdleNotifier
    {
        private readonly object SyncRoot = new object();
        private readonly Timer m_Timer;
        private IdleCallback m_IdleCallback = null;
        private TimeSpan m_IdleTimeSpanBeforeEvent = TimeSpan.Zero;
        // Null means there has been no action since last idle notification.
        private DateTime? m_LastActionTime = null;
        public IdleNotifierTimerImplementation()
        {
            m_Timer = new Timer(OnTimer);
        }
        private void OnTimer(object unusedState)
        {
            lock (SyncRoot)
            {
                if (m_LastActionTime == null)
                {
                    m_Timer.Change(m_IdleTimeSpanBeforeEvent, TimeSpan.Zero);
                    return;
                }
                TimeSpan timeSinceLastUpdate = DateTime.UtcNow - m_LastActionTime.Value;
                if (timeSinceLastUpdate > TimeSpan.Zero)
                {
                    // We are no idle yet.
                    m_Timer.Change(timeSinceLastUpdate, TimeSpan.Zero);
                    return;
                }
                m_LastActionTime = null;
                m_Timer.Change(m_IdleTimeSpanBeforeEvent, TimeSpan.Zero);
            }
            if (m_IdleCallback != null)
            {
                m_IdleCallback();
            }
        }
        // IdleNotifier implementation below
        public void ActionOccured()
        {
            lock (SyncRoot)
            {
                m_LastActionTime = DateTime.UtcNow;
            }
        }
        public IdleCallback Callback
        {
            set
            {
                lock (SyncRoot)
                {
                    m_IdleCallback = value;
                }
            }
        }
        public TimeSpan IdleTimeSpanBeforeCallback
        {
            set
            {
                lock (SyncRoot)
                {
                    m_IdleTimeSpanBeforeEvent = value;
                    // Run OnTimer immediately
                    m_Timer.Change(TimeSpan.Zero, TimeSpan.Zero);
                }
            }
        }
    }
