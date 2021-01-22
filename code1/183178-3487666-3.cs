    public DataTable m_alRecord;// don't use it
    private DataTable alRecord
    {
        get
        {
            if (m_alRecord == null)
            {
                m_alRecord = new DataTable();
                if (File.Exists(alFile))
                { m_alRecord.ReadXml(alFile); }
                else
                { InitDataTable2(m_alRecord); }
            }
            return _alRecord;
        }
        set { m_alRecord = value; }
    }
