        #endregion
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (m_armed)
                {
                    int refcnt = 0;
                    do
                    {
                        refcnt = System.Runtime.InteropServices.Marshal.ReleaseComObject(m_comObject);
                    } while (refcnt > 0);
                    m_comObject = default(T);
                }
                m_disposed = true;
            }
        }
    }
