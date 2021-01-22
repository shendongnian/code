<ComboBox x:Name="SearchBox" IsEditable="True" KeyUp="SearchBox_KeyUp" 
          PreviewMouseDown="SearchBox_PreviewMouseDown" IsTextSearchEnabled="False"
          DropDownOpened="SearchBox_DropDownOpened">
</ComboBox>
Code:
private void SearchBox_KeyUp(object sender, KeyEventArgs e)
{
    SearchBox.IsDropDownOpen = true;
    if (e.Key == Key.Down || e.Key == Key.Up)
    {
        e.Handled = true;
        //if trying to navigate but there's noting selected, then select one
        if(SearchBox.Items.Count > 0 && SearchBox.SelectedIndex == -1)
        {
            SearchBox.SelectedIndex = 0;
        }
    }
    else if (e.Key == Key.Enter)
    {
        //commit to selection
    }
    else if (string.IsNullOrWhiteSpace(SearchBox.Text))
    {
        SearchBox.Items.Clear();
        SearchBox.IsDropDownOpen = false;
        SearchBox.SelectedIndex = -1;
    }
    else if (SearchBox.Text.Length > 1)
    {
        //if something is currently selected, then changing the selected index later will loose
        //focus on textbox part of combobox and cause the text to
        //highlight in the middle of typing. this will "eat" the first letter or two of the user's search
        if(SearchBox.SelectedIndex != -1)
        {
            TextBox textBox = (TextBox)((ComboBox)sender).Template.FindName("PART_EditableTextBox", (ComboBox)sender);
            //backup what the user was typing
            string temp = SearchBox.Text;
            //set the selected index to nothing. sets focus to dropdown
            SearchBox.SelectedIndex = -1;
            //restore the text. sets focus and highlights the combobox text
            SearchBox.Text = temp;
            //set the selection to the end (remove selection)
            textBox.SelectionStart = ((ComboBox)sender).Text.Length;
            textBox.SelectionLength = 0;
        }
        //your search logic
    }
}
private void SearchBox_DropDownOpened(object sender, EventArgs e)
{
    TextBox textBox = (TextBox)((ComboBox)sender).Template.FindName("PART_EditableTextBox", (ComboBox)sender);
    textBox.SelectionStart = ((ComboBox)sender).Text.Length;
    textBox.SelectionLength = 0;
}
