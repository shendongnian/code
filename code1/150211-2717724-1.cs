    select new 
            {
                FailedCount = (grp.Key.TestResults == "F" ? grp.Count() : 0),
                CancelCount = (grp.Key.TestResults == "C" ? grp.Count() : 0),
                grp.Key.TestResults,
                grp.Key.FailStep,
                PercentFailed = Convert.ToDecimal(1.0 * grp.Count() / tcount * 100)
            }
