        private void ContentSplit_Panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            CaseFilter.Bounds = ContentSplit.Panel1.ClientRectangle;
            if(CaseFilter.Columns.Count == 1)
                CaseFilter.Columns[0].Width = CaseFilter.ClientRectangle.Width;
        }
