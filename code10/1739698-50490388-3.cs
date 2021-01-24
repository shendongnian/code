    var result = Transactions
        .GroupBy(transaction => transaction.RequestId)
        .Select(group => new
        {
            RequestId = group.Key
            GroupCount = group.Count(),
            SuccessCount = group
                .Where(groupElement => groupElement.ItemStatus == 0).Count(),
            WarningCount = group
                .Where(groupElement => groupElement.ItemStatus == 1).Count(),
            ErrorCount = group
                .Where(groupElement => groupElement.ItemStatus > 1).Count(),
            EndTime = group
                .Select(groupElement => groupElement.ExecutionDttm)
                .Max(),
         })
         .Select(item => new
         {
             RequestId = item.RequestId,
             TransactionCount = item.GroupCount,
             EndTime = item.EndTime,
             SuccessCount = 100.0 * item.SuccesCount / item.GroupCount,
             WarningCount = 100.0 * item.WarningCount / item.GroupCount,
             ErrorCount = 100.0 * item.ErrorCount / item.GroupCount,
         }
