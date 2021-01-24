		public static CommonOpenFileDialog OpenFileDialog(string title, List<CommonFileDialogFilter> filters, string initialDirectory = "", bool multiselect = false)
		{
			var openFilerDialog = new CommonOpenFileDialog();
			openFilerDialog.EnsureReadOnly = true;
			openFilerDialog.IsFolderPicker = false;
			openFilerDialog.AllowNonFileSystemItems = false;
			openFilerDialog.Multiselect = multiselect;
			openFilerDialog.Title = title;
			if (filters != null)
			{
				foreach (var filter in filters)
				{
					openFilerDialog.Filters.Add(filter);
				}
			}
			if (!string.IsNullOrEmpty(initialDirectory))
			{
				openFilerDialog.InitialDirectory = initialDirectory; // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			}
			return openFilerDialog;
		}
		private void CustomOpenFileDialog_Click(object sender, RoutedEventArgs e)
		{
			var dialog = FileDialog.OpenFileDialog("Custom OpenFileDialog", new List<CommonFileDialogFilter>() { new CommonFileDialogFilter("stl", "*.stl") });
			AddOpenFileDialogCustomControls(dialog);
			var dialogResult = dialog.ShowDialog();
		}
		public static void AddOpenFileDialogCustomControls(CommonFileDialog openDialog)
		{
			// Add a RadioButtonList
			CommonFileDialogRadioButtonList list = new CommonFileDialogRadioButtonList("radioButtonOptions");
			list.Items.Add(new CommonFileDialogRadioButtonListItem("Option A"));
			list.Items.Add(new CommonFileDialogRadioButtonListItem("Option B"));
			list.SelectedIndex = 1;
			openDialog.Controls.Add(list);
		}
