        string[] arrSplitItems;
        arrSplitItems = TestsOrdrd.Split(',');
        if (arrSplitItems.Length > 0)
        {
            for (int iCount = 0; iCount < arrSplitItems.Length; iCount++)
            {
                lstTestcode.Items.FindByValue(arrSplitItems[iCount].ToString()).Selected = true;
            }
        }
