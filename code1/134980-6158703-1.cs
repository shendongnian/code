		public int OnClose(ref uint pgrfSaveOptions)
		{
			// Check if your content is dirty here, then
			// Prompt a dialog
			MessageBoxResult res = MessageBox.Show("This Document has been modified. Do you want to save the changes ?",
						  "Unsaved changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
			// If the users wants to save
			if (res == MessageBoxResult.Yes)
			{
				// Handle with your "save method here"
			}
			if (res == MessageBoxResult.Cancel)
			{
				// If "cancel" is clicked, abort the close
				return VSConstants.E_ABORT;
			}
			// Else, exit
			return VSConstants.S_OK;
		}
