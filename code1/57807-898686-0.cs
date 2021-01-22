    class WaitCursor : IDisposable
    {
        Cursor m_previous;
        internal WaitCursor()
        {
            m_previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }
        #region IDisposable Members
        public void Dispose()
        {
            Cursor.Current = m_previous;
        }
        #endregion
    }
