                var result = _reputationHistoryRepository.GetAll()
                .Include(ips => ips.ReputationIp)
                .ThenInclude(ipGroups => ipGroups.ReputationMonitorGroup)
                .GroupBy(repHistory => repHistory.ReputationIpId)
                .Select(group => group
                    .OrderBy(repHistory => repHistory.CheckDateTime)
                    .TakeLast(countOfRecords)
                    .Select((reputationHistory, index) => new
                    {
                        GroupName = reputationHistory.ReputationIp.ReputationMonitorGroup.Name,
                        ReputationHostoryObject = reputationHistory,
                        RowNum = index
                    }))
                .SelectMany(reputationHistory => reputationHistory)
                .GroupBy(reputationHistory => new
                {
                    reputationHistory.RowNum,
                    reputationHistory.GroupName
                })
                .Select(reputationHistoryGroup => new
                {
                    Reputation = reputationHistoryGroup.Average(x => x.ReputationHostoryObject.Reputation),
                    GrpName = reputationHistoryGroup.Key.GroupName,
                    Value = reputationHistoryGroup.Key.RowNum
                });
