    myTabControl.SelectedIndexChanged += myTabControl_SelectedIndexChanged;
    private void myTabControl_SelectedIndexChanged(object sender, EventArgs e) {
        TabControl tc = sender as TabControl;
        if (tc.SelectedIndex == indexOfTabToShowFormOn) {
            TheSettingsForm.Show();
        }
    }
