    public DataTable m_alRecord;// don't use it
    private DataTable alRecord
    {
        get
        {
            if (_alRecord == null)
            {
                _alRecord = new DataTable();
                if (File.Exists(alFile))
                { _alRecord.ReadXml(alFile); }
                else
                { InitDataTable2(_alRecord); }
            }
            return _alRecord;
        }
        set { m_alRecord = value; }
    }
