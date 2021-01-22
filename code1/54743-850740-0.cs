    public partial class TimeSheet
    {
        public double Rate
        {
            get //Calculate your rate here... e.g.
            {
                if ((this.Employee == null) || (this.Employee.EmployeeHourlyRates.Count == 0))
                    //throw an exception
                EmployeeHourlyRate maxRate;
                foreach (EmployeeHourlyRate rate in this.Employee.EmployeeHourlyRates)
                {
                    if ((rate.EffectiveDate <= this.EntryDate)
                        && ((maxRate == null) || (maxRate.EffectiveDate < rate.EffectiveDate)))
                    {
                        maxRate = rate;
                    }
                }
                if (maxRate == null)
                    //throw exception
                else
                    return maxRate.Rate;
            }
        }
    }
