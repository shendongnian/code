      private void ClearSearchResults()
            {
                foreach (Control X in panel1.Controls)
                {
                    panel1.Controls.Remove(X);
                }
                if (panel1.Controls.Count > 0)
                { 
                    ClearSearchResults();
                }
            }
