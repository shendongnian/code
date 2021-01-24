    private void comboBoxModes_SelectedValueChanged(object sender, EventArgs e)
    {
        // Check for null because you will be called when SelectedIndex = -1
        if(comboBoxMode.SelectedItem != null)
        {
            KeyValuePair<string, Size> selection = comboBoxModes.SelectedItem;
            videoSource.VideoResolution = selection.Value;
        }
    }
