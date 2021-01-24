		private ICommand _SetValueCommand;
		public ICommand SetValueCommand => this._SetValueCommand ?? (this._SetValueCommand = new RelayCommand<string>(OnSetValue));
		private void OnSetValue(string key)
		{
			this.PropName = key;
			this.Value = this.Values[key];
		}
