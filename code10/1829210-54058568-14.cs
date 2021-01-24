    List<MeasurementSet__MultiStrata> resul_MultiStrata = 
	flattenedRawData.GroupBy(groupBy1 => groupBy1.EffectiveTIN)
    .Select(level1 => new MeasurementSet__MultiStrata
    {
        testTIN = level1.Key,
        measurements = level1.GroupBy(groupBy2 => groupBy2.MeasureID).Select(level2 =>
        new Measurement_MultiStrata()
        {
            measureId = level2.Key,
            value = new QualityMeasureValue_MultiStrata()
            {
            strata = level2.Select(level3 => new Strata
            {
                IsEndToEndReported = true,
                PerformanceMet = level3.PerformanceMetCount
            }).ToList(),
            }
        }).ToList()
    }).ToList();
	 
