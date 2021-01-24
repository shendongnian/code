    	public async Task<WaitForLoanActivationDto> WaitForLoanActivation(string userName, string accountGuid, int timeout)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			try
			{
				const int pollPeriod = 500;
				IClient client = await _rpcConnectionPool.GetClientAsync(userName);
				DateTime startTime = DateTime.Now;
				Task<WaitForLoanActivationDto> waitForLoanActivationDtoTask = null;
				while (startTime.AddMilliseconds(timeout) >= DateTime.Now)
				{
					if (waitForLoanActivationDtoTask == null)
					{
						waitForLoanActivationDtoTask = Task.Run(() => WaitForLoanActivationCallback(client, accountGuid), cancellationTokenSource.Token);
					}
					else
					{
						if (waitForLoanActivationDtoTask.IsCompleted)
						{
							if (waitForLoanActivationDtoTask.Result.Active)
							{
								break;
							}
							else
							{
								await Task.Delay(pollPeriod, cancellationTokenSource.Token).ContinueWith((_) => { waitForLoanActivationDtoTask = null; });
							}
						}
					}
				}
				return waitForLoanActivationDtoTask.Result;
			}
			catch (AggregateException ex)
			{
				cancellationTokenSource.Cancel();
				throw ex.InnerException;
			}
		}
		private WaitForLoanActivationDto WaitForLoanActivationCallback(IClient client, string accountGuid)
		{
			using (RPCReply reply = ResultHelper.Check(client.ExecuteRemoteCommand(WaitForLoanActivationRpcName, accountGuid)))
			{
				var waitForLoanActivationDto = new WaitForLoanActivationDto
				{
					Active = reply[2].IDList["Active"].AsBoolean().Value
				};
				VariantList statusList = reply[2].IDList["statuses"].List;
				if (statusList.Count > 0)
				{
					var statuses = CustomerInformationConverter.GetStatusesList(statusList);
					waitForLoanActivationDto.Statuses = statuses.ToArray();
				}
				return waitForLoanActivationDto;
			}
		}
