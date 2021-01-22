	void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsBusy")
		{
			if (this._modelViewAnalysis.IsBusy)
			{
				if (Application.Current.Dispatcher.CheckAccess())
				{
					this.Cursor = Cursors.Wait;
				}
				else
				{
					Application.Current.Dispatcher.Invoke(new Action(() => this.Cursor = Cursors.Wait));
				}
			}
			else
			{
				Application.Current.Dispatcher.Invoke(new Action(() => this.Cursor = null));
			}
		}
