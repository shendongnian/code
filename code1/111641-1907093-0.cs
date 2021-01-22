    private void saveAllMenuItem_Click(object sender, EventArgs e)
        {
            // Set up the config object .... with a default user level.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isWindowsDriveSet())
            {
                // Save the drive name and write it to a config file.
                config.AppSettings.Settings.Add("Drive", WindowsDrive());
            }
            else
            {
                MessageBox.Show("Please set your windows drive before proceeding!", "Windows Drive Not Set!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (ShowHiddenFilesSetting()) // only true (executes) if the app is showing 'ALL' files.
            {
                config.AppSettings.Settings.Add("FileSettings", FileSettings());
            }
            else // else default is implied.
            {
                config.AppSettings.Settings.Add("FileSettings", FileSettings());            
            }
            // Notify the user that the method has completed successfully.
            toolStripStatusLabel.Text = "Settings saved.";
            // Log to the logger what has just happened here.
            ActionOccured(this, new ActionOccuredEventArgs("0", DateTime.Now.ToString(), "The user has saved his settings."));
            
            // Finally save to the config.
            config.Save();
        }
