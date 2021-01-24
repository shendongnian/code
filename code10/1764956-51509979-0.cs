	private bool _CheckStatus;
	public bool CheckStatus
	{
		get { return this._CheckStatus; }
		set
		{
			if (this._CheckStatus != value)
			{
				this._CheckStatus = value;
				RaisePropertyChanged(() => this.CheckStatus);
			}
		}
	}
