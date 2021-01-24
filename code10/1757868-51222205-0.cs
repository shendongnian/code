		public string ResourceDescription
		{
        get
        {
            return _Resource.Description;
        }
				set
				{
					_Resource.Description = value;
					NotifyOfPropertyChange(() => ResourceDescription);
					NotifyOfPropertyChange(() => Resource);
					NotifyOfPropertyChange(() => CanSave);
				}
		}
