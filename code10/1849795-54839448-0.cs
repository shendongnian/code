    private void searchBtn_Click(object sender, EventArgs e)
    {
        for (int i = listBoxHist.Items.Count - 1; i >= 0; i--)
        {
            if (listBoxHist.Items[i].ToString().Contains(textboxSearch.Text))
                listBoxHist.SetSelected(i, true);
            else
                listBoxHist.Items.RemoveAt(i);
        }
    }
