    private void dataGridView2_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e) 
    {
        try
        {
            if (string.IsNullOrEmpty(dataGridView2.SortString) == true)
                return;
    
            var sortStr = dataGridView2.SortString.Replace("[", "").Replace("]", "");
    
            if (string.IsNullOrEmpty(dataGridView2.FilterString) == true)
            {
                // the grid is not filtered!
                m_dataGridBindingList = m_dataGridBindingList.OrderBy(sortStr).ToList();
                dataGridView2.DataSource = m_dataGridBindingList;                    
            }
            else
            {
                // the grid is filtered!
                m_filteredList = m_filteredList.OrderBy(sortStr).ToList();
                dataGridView2.DataSource = m_filteredList;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        }
    }
