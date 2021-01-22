    private void SetCutState(ListViewItem lvi, Boolean isItemCut)
    {
        int originalListSize = lvi.ImageList.Images.Count / 2;
        int baseIndex = lvi.ImageIndex % originalListSize;
        int cutImagesOffset = originalListSize;
    
        if (isItemCut)
        {
            lvi.ImageIndex = cutImagesOffset + baseIndex;
            lvi.ForeColor = SystemColors.GrayText;
        }
        else
        {
            lvi.ImageIndex = baseIndex;
            lvi.ForeColor = SystemColors.WindowText;
        }
    }
