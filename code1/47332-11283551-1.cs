        /// <summary>
        /// This is the preferred way to return to the operating system.
        /// </summary>
        public void ExitAndTidyUP()
        {
    #if WINDOWS
            WindowsHelperAccessibilityKeys.AllowAccessibilityShortcutKeys(true);
    #endif
            Exit();
        }
