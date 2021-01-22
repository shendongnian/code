    this.DoubleClick += new EventHandler(this.EditableDoubleClick);
    
    private void EditableDoubleClick(object sender, System.EventArgs e)
    {
    
    selectedItemText = selectedItem.ToString();
    
    innerTextBox.Size = new Size(subItemRect.right - subItemRect.left, subItemRect.bottom - subItemRect.top);
    
    innerTextBox.Location = new Point(subItemRect.left, subItemRect.top);
    
    innerTextBox.Show();
    
    innerTextBox.Text = selectedItemText;
    
    }
