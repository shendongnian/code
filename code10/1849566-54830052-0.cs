        var total = (from TD in ingestionHubContext.TransactionDetail
                            join P in provider on TD.TrustCode equals P.Code
                            join M in measure on TD.MetricCode equals M.InternalId
    // Here is how
                            join MV in measureValue on new {M.Id, P.Id} equals new {MV.MeasureId, MV.ProviderId}
    // the rest is your original where statement
                            where TD.BatchId == batchId && TD.RowAction == "A"
                            && (M.Type == 7 || M.Type == 8) && TD.Value != MV.Value
                            group TD by new { MV.MeasureId, MV.ProviderId } into Total
                            select Total);
