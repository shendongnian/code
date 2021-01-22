    private void ClearSearchResults()
    {
        for (int i=0 ; i < panel1.Controls.Length; i++)
        {
            panel1.Controls.RemoveAt(i);
        }
    }
