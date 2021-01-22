    [Serializable()]
    public class CConfigDO
    {
        private System.Drawing.Point m_oStartPos;
        private System.Drawing.Size m_oStartSize;
        public System.Drawing.Point StartPos
        {
            get { return m_oStartPos; }
            set { m_oStartPos = value; }
        }
        public System.Drawing.Size StartSize
        {
            get { return m_oStartSize; }
            set { m_oStartSize = value; }
        }
    }
