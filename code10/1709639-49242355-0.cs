      MailMessage msg  = new MailMessage();
        List<int> sizeAttachement = new List<int>();
        List<string> nameAttachement = new List<string>();
        if(ofd.ShowDialog()==DialogResult.OK) 
        {
        
            path = ofd.FileName.ToString();
            FileInfo info = new FileInfo(ofd.FileName);
            sizeAttachement.Add(Convert.ToInt32(info.Length / (1024 * 1024)));
            nameAttachement.Add(ofd.FileName);
        }
        private void delAtchButton_Click(object sender, EventArgs e)
        {
             if (attachementListBox.SelectedIndex == -1)
             {
        
             }
             else
             {
                    ListBox.SelectedObjectCollection selectedItems = new 
                    ListBox.SelectedObjectCollection(attachementListBox);
                    selectedItems = attachementListBox.SelectedItems;
                    if (attachementListBox.SelectedIndex != -1)
                    {
                        int attachementListBoxindex = attachementListBox.SelectedIndex;
                        for (int i = selectedItems.Count - 1; i >= 0; i--)
                        attachementListBox.Items.Remove(selectedItems[i]);
                        msg.Attachments.RemoveAt(attachementListBoxindex); //Error always occurs
        
        
        
                        attachementProgressBar.Increment(-sizeAttachement[attachementListBoxindex]);
                        sizeAttachement.RemoveAt(attachementListBoxindex);
                        procentage = attachementProgressBar.Value * 4;
                        procentageLabel.Text = Convert.ToString(procentage) + "%";
        
        
                        for (int z = 0; z <= nameAttachement.Count; z++)
                        {
                            foreach (Attachment attachment in msg.Attachments)
                            {
                                if (attachment.Name == Convert.ToString(nameAttachement[z]))
                                {
                                    msg.Attachments.Remove(attachment); //Error to
                                    break;
                                }
                            }
                        }
    }  
                         
