    public class AutoReleaseComObject<T> : IDisposable
    {
        private T m_comObject;
        private bool m_armed = true;
        private bool m_disposed = false;
        public AutoReleaseComObject(T comObject)
        {
            Debug.Assert(comObject != null);
            m_comObject = comObject;
        }
    #if DEBUG
        ~AutoReleaseComObject()
        {
            // We should have been disposed using Dispose().
            Debug.WriteLine("Finalize being called, should have been disposed");
        
            if (this.ComObject != null)
            {
                Debug.WriteLine(string.Format("ComObject was not null:{0}, name:{1}.", this.ComObject, this.ComObjectName));
            }
        
            //Debug.Assert(false);
        }
    #endif
        public T ComObject
        {
            get
            {
                Debug.Assert(!m_disposed);
                return m_comObject;
            }
        }
    
        private string ComObjectName
        {
            get
            {
                if(this.ComObject is Microsoft.Office.Interop.Excel.Workbook)
                {
                    return ((Microsoft.Office.Interop.Excel.Workbook)this.ComObject).Name;
                }
    		
                return null;
            }
        }
        public void Disarm()
        {
            Debug.Assert(!m_disposed);
            m_armed = false;
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
    #if DEBUG
            GC.SuppressFinalize(this);
    #endif
        }
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
