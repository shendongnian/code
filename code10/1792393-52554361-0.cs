	public bool? DialogResult
	{
		get
		{
			this.VerifyContextAndObjectState();
			this.VerifyApiSupported();
			return this._dialogResult;
		}
		set
		{
			this.VerifyContextAndObjectState();
			this.VerifyApiSupported();
			if (this._showingAsDialog)
			{
				if (this._dialogResult != value)
				{
					this._dialogResult = value;
					if (!this._isClosing)
					{
						this.Close();
						return;
					}
				}
				return;
			}
			throw new InvalidOperationException(SR.Get("DialogResultMustBeSetAfterShowDialog"));
		}
	}
