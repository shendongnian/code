        private void listBoxAllTags_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            FontStyle fontStyle = FontStyle.Regular;
            if(e.Index < searchedTagList.Count)
            {
                fontStyle = FontStyle.Bold;
            }
            if(listBoxAllTags.Items.Count > 0) // Without this, I receive errors
            {
                e.Graphics.DrawString(listBoxAllTags.Items[e.Index].ToString(), new Font("Arial", 8, fontStyle), Brushes.Black, e.Bounds);
            }
            e.DrawFocusRectangle();
        }
