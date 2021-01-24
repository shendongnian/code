    var query = from td in transactionDetails
                            join p in providers on td.TrustCode equals p.Code
                            join m in measures on td.MetricCode equals m.InternalId
                            join mv in measureValues on new { mId = m.Id, pId = p.Id } equals new { mId = mv.MeasureId, pId = mv.ProviderId }
                            where td.BatchId == batchId && td.RowAction == "A"
                            && (m.Type == 7 || m.Type == 8) && td.Value != mv.Value
                            select new { td, p, m, mv } into queryList
                            group queryList by new { queryList.mv.MeasureId, queryList.mv.ProviderId } into groupedList
                            select new {
                                groupedList.Key.MeasureId,
                                groupedList.Key.ProviderId,
                                mostRecentReportingDate = groupedList.Max(g => g.mv.ReportingDate) };
