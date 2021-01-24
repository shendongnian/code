    public void OnCheckedChanged(CheckBox checkbox)
    {
        if (selectedFileList == null)
        {
            selectedFileList = new List<string>();
        }
        
        string test = checkbox.Id.ToString();
        string checkedName = checkbox.Text;
        
        if (checkbox.Checked)
        {
            selectedFileList.Add(checkedName);
        }
        else
        {
            selectedFileList.Remove(checkedName);
        }
    }
