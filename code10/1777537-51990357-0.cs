    private void buttonRename_Click(object sender, EventArgs e)
    {
        if (outputListBox.SelectedIndex >=0)
        {
        	string fileToRename = outputListBox.Items.SelectedItem.ToString();
        	string newFileName = InputBox("Please enter the new file's name:", "Rename file", "Default value");
        	if (!string.IsNullOrEmpty(newFileName))
        	{
        		string fileName = Path.GetFileName(fileToRename);
        		string newFilePath = fileToRename.Replace(fileName, newFileName);
        		System.IO.File.Move(fileToRename, newFilePath);
            	outputListBox.Items[outputListBox.SelectedIndex] = newFilePath;
        	}
        }
        else
        {
            MessageBox.Show("There is no Files in the Above list to be Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
