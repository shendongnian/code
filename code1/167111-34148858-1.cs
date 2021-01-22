    private Timer _tmrDelaySearch;
    private const int DelayedTextChangedTimeout = 500;
    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (_tmrDelaySearch != null)
        _tmrDelaySearch.Stop();
        
        if (_tmrDelaySearch == null)
        {
            _tmrDelaySearch = new Timer();
            _tmrDelaySearch.Tick += _tmrDelaySearch_Tick;
            _tmrDelaySearch.Interval = DelayedTextChangedTimeout;
        }
        
        _tmrDelaySearch.Start();
    }
    
    void _tmrDelaySearch_Tick(object sender, EventArgs e)
    {
        if (stcList.SelectedTab == stiTabSearch) return;
        string word = string.IsNullOrEmpty(txtSearch.Text.Trim()) ? null : txtSearch.Text.Trim();
        
        if (stcList.SelectedTab == stiTabNote)
        FillDataGridNote(word);
        else
        {
            DataGridView dgvGridView = stcList.SelectedTab == stiTabWord ? dgvWord : dgvEvent;
            int idType = stcList.SelectedTab == stiTabWord ? 1 : 2;
            FillDataGrid(idType, word, dgvGridView);
        }
        
        if (_tmrDelaySearch != null)
        _tmrDelaySearch.Stop();
    }
