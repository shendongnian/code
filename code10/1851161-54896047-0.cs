    var wqReqIds = requests.Select(x => x.WorkQueueRequestId).ToList();
    var aliases = db.WorkQueueRequestDetails.Where(x => wqReqIds.Contains(x.WorkQueueRequestId))
            .GroupBy(x => x.AssociatesHistory.Alias)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .ToList();
    var allWqAssociates = db.WorkQueueRequestDetails.Where(w => wqReqIds.Contains(w.WorkQueueRequestId))
            .ToList()
            .Select(x => new AssociateInfo
            {
                WorkQueueRequestId = x.WorkQueueRequestId,
                Alias = aliases.Any(y => y == x.AssociatesHistory.Alias)
                    ? "***" + x.AssociatesHistory.Alias
                    : x.AssociatesHistory.Alias,
                Name = x.AssociatesHistory.ToString()
            });
