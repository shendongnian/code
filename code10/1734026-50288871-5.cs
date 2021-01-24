    private bool isSelected;
		public bool IsSelected
		{
			get
			{
				return this.isSelected;
				
			}
			set
			{
				this.isSelected = value;
				OnPropertyChanged("IsSelected");
			}
		}
