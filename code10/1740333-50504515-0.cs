    public void SelectFiles()
    {
         int i;
         SelectedFileText.Text = "";
         dlg = new Microsoft.Win32.OpenFileDialog();
         dlg.Multiselect = true;
         Nullable<bool> result = dlg.ShowDialog();
         foreach (String filename in dlg.FileNames)
         {
             SelectedFileText.Text += filename + "\n";
             uploadFileList.Add(filename);
         }
    }
