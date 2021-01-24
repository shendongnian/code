    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
          var selectedTab = ((TabControl)sender).SelectedTab.Name;
    
          if (selectedTab == "Callibration")
          {
               rdCallibrationCameraMethod.CheckedChanged -= rdCallibrationCameraMethod_CheckedChanged;
               rdCallibrationCameraMethod.Checked = rdCameraMethod.Checked;
             }
          }
