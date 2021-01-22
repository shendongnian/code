            // Search text and Highlight it (Per Click)
        // Manually add the "FindText"
        public int FindText(string txtToSearch, int searchStart, int searchEnd)
        {
            // Unselect the previously searched string
            if (searchStart > 0 && searchEnd > 0 && IndexOfSearchText >= 0)
            { rtb.Undo(); }
            // Set the return value to -1 by default.
            int retVal = -1;
            // A valid starting index should be specified.
            // if indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && IndexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    IndexOfSearchText = rtb.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                    // Determine whether the text was found in richTextBox1.
                    if (IndexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = IndexOfSearchText;
                    }
                }
            }
            return retVal;
        }
        // Button to Perform the Search (By Click)
        private void btn_Search_Click(object sender, EventArgs e)
        {
            int startIndex = 0;
            if (txt_Search.Text.Length > 0) startIndex = FindText(txt_Search.Text.Trim(), start, rtb.Text.Length);
            // If string was found in the RichTextBox, highlight it
            if (startIndex >= 0)
            {
                int x = rtb.Find(txt_Search.Text);
                rtb.SelectionStart = x;
                rtb.Focus();
                // Set the highlight color as red
                rtb.SelectionBackColor = Color.LightYellow;  // Remove to prevent Minor Bug
                rtb.SelectionColor = Color.Black;            // Remove to prevent Minor Bug
                // Find the end index. End Index = number of characters in textbox
                int endindex = txt_Search.Text.Length;
                // Highlight the search string
                rtb.Select(startIndex, endindex);
                // mark the start position after the position of
                // last search string
                start = startIndex + endindex;
            }
        }
        // TextBox used for Searching
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            start = 0;
            IndexOfSearchText = 0;
        }
    }
