    List<DataPointGridViewModel> m_dataGridBindingList = null;
    List<DataPointGridViewModel> m_filteredList = null;
    
    private void dataGridView2_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
    {
        try
        {
            if ( string.IsNullOrEmpty(dataGridView2.FilterString) == true )
            {
                m_filteredList = m_dataGridBindingList;
                dataGridView2.DataSource = m_dataGridBindingList;
            }
            else
            {
                var listfilter = FilterStringconverter(dataGridView2.FilterString);
    
                m_filteredList = m_filteredList.Where(listfilter).ToList();
    
                dataGridView2.DataSource = m_filteredList;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        }
    }
