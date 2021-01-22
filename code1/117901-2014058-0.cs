    private void SetReportDataSource()
    {
        using (DataSet1 ds = m_RptData.GetDataSet)
        {
            m_Rpt.SetDataSource(ds);
        }
    }
