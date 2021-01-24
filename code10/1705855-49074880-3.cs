	public static Expression<Func<MessageLogRecord, bool>> MessageIsPendingResponse
	{
		get
		{
			Expression<Func<CCI_Int_ExportLog, bool>> expr = PredicateBuilder.True<MessageLogRecord>()
				.And(MessageIsProcessed)
				.And(MessageIsInbound)
				.And(ResponseNotYetSent)
			;
			return expr;
		}
	}
