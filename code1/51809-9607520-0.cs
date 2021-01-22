			get { return _OfficiantNameMiddle.GetValueOrNull(); }
			set 
			{
				value = value.GetValueOrNull();
				if (_OfficiantNameMiddle != value) 
				{
					_IsDirty = true;
					OnOfficiantNameMiddleChanging(value);
					SendPropertyChanging("OfficiantNameMiddle");
					_OfficiantNameMiddle = value;
					SendPropertyChanged("OfficiantNameMiddle");
					OnOfficiantNameMiddleChanged();
				}
			}
