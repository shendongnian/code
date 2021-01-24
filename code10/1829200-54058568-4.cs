		List<MeasurementSet__MultiStrata> resul_MultiStrata = 
			flattenedRawData.GroupBy(records => records.EffectiveTIN)
			 .Select
			   (y => new MeasurementSet__MultiStrata
				   {
					   testTIN = y.Key,
					   measurements = y.Select
							(i =>
							   new Measurement_MultiStrata()
							   {
								   measureId = i.MeasureID,
								   value = new QualityMeasureValue_MultiStrata
								   {
									   strata = new List<Strata>() 
									   { 
											new Strata() 
											{ 
												IsEndToEndReported = true, 
												PerformanceMet = i.PerformanceMetCount 
											} 
										 }
								   }
							   }
							).ToList()
				   }
			   )
	   .ToList();
	 
