        private void AddLink_Click(object sender, EventArgs e)
        {
            // do proper validation and add only proper links
            // this will help you to avoid the exception 
            if (!string.IsNullOrEmpty(textLinkData.Text) && 
                nudLinkAreaEnd.Value > 0 && 
                nudLinkAreaStart.Value >= 0 && 
                nudLinkAreaStart.Value < llblinkLabel1.Text.Length)
           {
               LinkLabel.Link link = new LinkLabel.Link();
               link.Description = textDescription.Text.ToString();
               link.LinkData = textLinkData.Text.ToString();
               link.Name = textName.Text.ToString();
               link.Enabled = checkBoxEnabled.Checked;
               link.Visited = checkBoxVisited.Checked;
               link.Start = (int)nudLinkAreaStart.Value;
               link.Length = (int)nudLinkAreaEnd.Value;
               try
               {
                   llblinkLabel1.Links.Add(link); 
               }
               catch (InvalidOperationException exception) // links can't overlap 
               {
                   MessageBox.Show("Links are overlaping");
               }
               
           }
