    var entries = atisDAO.GetPME(xl, null);
    response.Data.Detectors = new List<DetectorDetails>(entries.Select(pme =>{
        var details = new DetectorDetails { ID = pme.PlaceNum.ToString()};
        var summaries = atisDAO.GetSummaryEntries(pme.PlaceNum);
        if (summaries.Any())
        {
            var count = summaries.Sum(summary => summary.TODCount + summary.BFICount + summary.ViolationCount);
            var detectionDate = summaries.Max(summary => summary.ReadDate);
            details.Count = count.ToString();
            details.DetectionTime = new DateTimeZone {
                ReadDate = detectionDate.ToString(DATE_FORMAT)
                , ReadTime = detectionDate.ToString(TIME_FORMAT)
            };
         }
         return details;
    }));
