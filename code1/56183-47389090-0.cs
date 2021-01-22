        ToolTip m_ttInput = new ToolTip(); // define as member variable
        private void rtbInput_SelectionChanged(object sender, EventArgs e)
        {
            if (rtbInput.SelectedText.Length > 0) 
            {
                m_ttInput.Show(rtbInput.SelectedText.Length.ToString(), rtbInput, 1000);
            }
        }
