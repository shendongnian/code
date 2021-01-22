    private void RunOperationWithMainProgressFeedback(
		Func<bool> operation,
		string startMessage,
		string completionMessage,
		string cancellationMessage,
		string errorMessage)
	{
		this._UpdateMainForm.BeginInvoke(startMessage, false, null, null);
		try
		{
			if (operation.Invoke())
			{
				this._UpdateMainForm.BeginInvoke(completionMessage, true, null, null);
			}
			else
			{
				this._UpdateMainForm.BeginInvoke(cancellationMessage, true, null, null);
			}
		}
		catch (Exception)
		{
			this._UpdateMainForm.BeginInvoke(errorMessage, true, null, null);
			throw;
		}
	}
	private void btnX_Click(object sender, EventArgs e)
	{
		this.RunOperationWithMainProgressFeedback(
			this.UpdateOperationA,
			"StartA",
			"CompletedA",
			"CanceledA",
			"ErrorA");
	}
