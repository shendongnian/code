    //When the Save button is clicked the contents of the text box will be written to a text file.
    private void saveButton_Click(object sender, EventArgs e)
    {
        int textBoxLines = textBox.Lines.Count();
    
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        saveDialog.FilterIndex = 2;
        saveDialog.RestoreDirectory = true;
        saveDialog.FileName = (saveFile);
        saveDialog.InitialDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
    
        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            using (Stream savestream = saveFialog.OpenFile())
            {
    
                if (saveStream != null)
                {
                    using(StreamWriter tw = new StreamWriter(saveStream))
                    {
    
                        for (int i = 0; i < textBoxLines; i++)
                        {
                            tw.WriteLine(textBox.Lines.GetValue(i));
                        }
                    }
                }
            }
        }
    }
