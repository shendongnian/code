    x.Select(y => y.WorkedDataPointsList).ForEach((wdp) =>
        {
            if (testtech == wdp.AssignerName && IniDate.Date <= wdp.Date.Date
                && wdp.Date.Date <= EndDate.Date)
            {
                workingDatesList.Add(wdp.Date.Date);
            }
        });
