      int m_iRowIdx = 0;
        protected void ctlGridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "onGridViewRowSelected('" + m_iRowIdx.ToString() + "')");
            }
            m_iRowIdx++;
        }
