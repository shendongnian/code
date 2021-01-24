     private void comboBoxModes_SelectedValueChanged(object sender, EventArgs e)
    {
        if (modes.ContainsKey(comboBoxModes.Text))
        {
            Size value = modes[comboBoxModes.Text];
            videosource.VideoResolution = value;
        }
    }
