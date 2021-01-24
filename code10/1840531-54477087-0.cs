	var measurementUnits = new [] {
	    new { Unit = "SQF", Display = new List<string>() { "F", "FT", "SQ FT" }, Ratio=1.5 } ,
	    new { Unit = "Hectares", Display = new List<string>() { "H", "HEC"} , Ratio=2.5},
	    new { Unit = "Acres", Display = new List<string>() { "AC(TO)" } , Ratio=3.5},
	    new { Unit = "SQM", Display = new List<string>() {  "M", "SQ M"}, Ratio=4.5 }
	};
	
	var multiplier = measurementUnits.Where(m=>m.Display.Contains("HEC")).First().Ratio;
