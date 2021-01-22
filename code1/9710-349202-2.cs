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
