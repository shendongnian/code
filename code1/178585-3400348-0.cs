         /// <summary>
        /// Get the selected file of the active window
        /// </summary>
        /// <param name="handle">Handle of active window</param>
        /// <returns></returns>
        public String getSelectedFileOfActiveWindow(Int32 handle)
        {
            try
            {
                foreach (InternetExplorer window in shellWindows)
                {
                    if (window.HWND == handle)
                        return ((Shell32.IShellFolderViewDual2)window.Document).FocusedItem.Path;
                }                
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
