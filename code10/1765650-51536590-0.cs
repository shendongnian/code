    public class YourViewVM : INotifyPropertyChanged
	{
		#region Fields
		private object selectedDataGridCell;
		private string textBoxContent;
		private List<YourObject> dataGridSource;
		#endregion
		#region Properties
		public object SelectedDataGridCell
		{
			get
			{
				return this.selectedDataGridCell;
			}
			set
			{
				if (this.selectedDataGridCell != value)
				{
					this.selectedDataGridCell = value;
					OnPropertyChanged("SelectedDataGridCell");
				}
			}
		}
		public string TextBoxContent
		{
			get
			{
				return this.textBoxContent;
			}
			set
			{
				if (this.textBoxContent != value)
				{
					this.textBoxContent = value;
					OnPropertyChanged("TextBoxContent");
				}
			}
		}
		public List<YourObject> DataGridSource
		{
			get
			{
				return this.dataGridSource;
			}
			set
			{
				if (this.dataGridSource != value)
				{
					this.dataGridSource = value;
					OnPropertyChanged("Source");
				}
			}
		}
		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
