     class Hotkey
    {
        private static KeyboardHookListener _keyboardHookListener;
        public void Start()
        {
            _keyboardHookListener = new KeyboardHookListener(new GlobalHooker()) { Enabled = true };
            _keyboardHookListener.KeyDown += KeyboardListener_OnkeyPress;
        }
        private void KeyboardListener_OnkeyPress(object sender, KeyEventArgs e)
        {
            // Let's backup all projects
            if (e.KeyCode == Keys.F1)
            {
                // Initialize files
                var files = new Files();
                // Backup all projects
                files.BackupAllProjects();
            }
            // Quick backup - one project
            else if (e.KeyCode == Keys.F2)
            {
                var quickBackupForm = new QuickBackup();
                quickBackupForm.Show();
            }
        }
    }
