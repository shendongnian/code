    private void ClearSearchResults()
    {
        for(int i=panel1.Controls.Count-1;i>=0;--i) {
            panel1.Controls.RemoveAt(i);        
            // or
            // Control X = panel1.Controls[i];
            // panel1.Controls.Remove(X);
        }
    }
