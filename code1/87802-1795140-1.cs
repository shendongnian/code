    private void CallCellReader(ArrayList myArray, int Count, int noRec)
    {
        try
        {
            char c = 'A';
            for (int l = 1; l <= Count; l++)
            {
                int k = 2;
                for (int i = 1; i <= noRec; i++)
                {
                    m_objRange = m_objSheet.get_Range(c.ToString() + k.ToString(), c.ToString() + k.ToString());
                    myArray.Add(m_objRange.Cells.Value2.ToString());
                    k++;
                }
                c++;
            }
        }
        catch (Exception exc)
        {
            Log.Add("Error in Reading Excel file " +exc);
            LogFlag = 1;
        }
    }
