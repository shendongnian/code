    var ans = interactionLogs.GroupBy(il => new { il.DeviceId, il.Id, il.Direction })
                .Select(ilg => new {
                    ilg.Key,
                    Count = ilg.OrderBy(il => il.Timestamp)
                               .ScanPair(il => (firstTimestamp: il.Timestamp, groupNum: 1), (kvp, cur) => (cur.Timestamp - kvp.Key.firstTimestamp).TotalMinutes <= 15 ? kvp.Key : (cur.Timestamp, kvp.Key.groupNum + 1))
                               .GroupBy(ilkvp => ilkvp.Key.groupNum, ilkvp => ilkvp.Value)
                               .Count()
                });
