    var inspectionsDates = (from i in InspectionVisits where i.cityID == ctid && i.centreID == centreid orderby i.datePerformed select i.datePerformed).ToList();
		for(int i=0; i< inspectionsDates.Count-1; i++)
		{
			if (!errorsPerIV.Any(a=>a.PreviousInspection == inspectionsDates[i]))
			{
				errorsPerIV.Add(new Summary() { PreviousInspection = inspectionsDates[i], NextInspection = inspectionsDates[i + 1], Errors = 0});
			}
		}
