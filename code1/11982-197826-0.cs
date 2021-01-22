		[Column(Storage="_ParentKey", DbType="Int")]
		public System.Nullable<int> ParentKey
		{
			get
			{
				return this._ParentKey;
			}
			set
			{
				if ((this._ParentKey != value))
				{
					//This code is added by the association
					if (this._Parent.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					//This code is present regardless of association
					this.OnParentKeyChanging(value);
					this.SendPropertyChanging();
					this._ParentKey = value;
					this.SendPropertyChanged("ParentKey");
					this.OnServiceAddrIDChanged();
				}
			}
		}
