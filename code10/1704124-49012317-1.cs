	public async Task<DomainResult<IList<MbRiskDto>>> QueryAsync(Action<MbrAccountAutoMatcherQueryParameter> parameter,
		CancellationToken cancellationToken = default(CancellationToken))
	{
		parameter(_parameter);
		var nonDeclaredMbrAccounts = await _nonDeclaredMbrAccountsQuery.QueryAsync(param => param.TransactionDate = _parameter.TransactionDate, cancellationToken);
		if (nonDeclaredMbrAccounts.IsFailed)
			nonDeclaredMbrAccounts.Errors.ForEach(error => _errors.Add(error));
		var taskList = new List<Task<MbRiskDto>>();
		foreach (var nonDeclaredAccount in nonDeclaredMbrAccounts.Result)
		{
			var account = (AccountDto) nonDeclaredAccount.Clone();
			var firstAccountHolder = Convert.ToInt32(account.AccountHolders.FirstOrDefault());
			Func<Task<MbRiskDto>> mbRiskTask = async ()  => new MbRiskDto
			{
				KimNo = await GetKimNo(firstAccountHolder, cancellationToken),
				HesNo = account.AccountNo,
				FinCode = await GetFinanceCode(account, firstAccountHolder, cancellationToken),
				Unvan = account.SMA.Substring(0, Math.Min(account.SMA.Length, 54))
			};
			//var task = Task.Run();
			taskList.Add(mbRiskTask.Invoke());
		}
		var taskResult = await Task.WhenAll(taskList);
		return DomainResult<IList<MbRiskDto>>.Success(taskResult);
	}
