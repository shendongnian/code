    private void OnSelectButtonTapped(object sender, int e)
        {
    
                    if (!(serialNoList.Contains(stockLists[RowNo].SerialNo)))
                        serialNoList.Add(stockLists[RowNo].SerialNo);
                    else
                        serialNoList.Remove(stockLists[RowNo].SerialNo);
                    SetUpperPanelData();
        }
