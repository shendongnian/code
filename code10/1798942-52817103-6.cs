    public class YourParentVMDataSource
	{
		private YourParentVM yourParentVM;
		private GlobalShortcutsVM globalShorcutsVM;
		public YourParentVMDataSource(GlobalShortcutsVM globalShortcutsVm, YourParentVM yourParentVM)
		{
			this.globalShorcutsVM = globalShortcutsVm;
			this.yourParentVM = yourParentVM;
		}
		public void CreateDataSource()
		{
			this.globalShorcutsVM.Model.PropertyChanged += this.OnGlobalShortcutsModelPropertyChanged
		}
		private void OnGlobalShortcutsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "ShortcutName":
					this.yourParentVM.RaisePropertyChanged("IsButtonSaveEnabled");
					break;
				case "FilePath":
					this.yourParentVM.RaisePropertyChanged("IsButtonSaveEnabled");
					break;
			}
		}
	}
