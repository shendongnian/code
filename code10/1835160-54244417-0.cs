    foreach(TabPage tabPage in yourTabControl.Controls)
    {
        foreach (TextBox textBox in tabPage.Controls.OfType<TextBox>().Where(x=>x.AccessibleName == ((Control)sender).AccessibleName))
        {
            Clipboard.SetDataObject(textBox.Text);
        }
    }
