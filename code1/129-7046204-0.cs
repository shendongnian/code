	public static Dictionary<string,int> CurrentAgeInYearsMonthsDays(DateTime? ndtBirthDate, DateTime? ndtReferralDate)
		{
			//----------------------------------------------------------------------
            // Can't determine age if we don't have a dates.
            //----------------------------------------------------------------------
            if (ndtBirthDate == null) return null;
            if (ndtReferralDate == null) return null;
            DateTime dtBirthDate = Convert.ToDateTime(ndtBirthDate);
            DateTime dtReferralDate = Convert.ToDateTime(ndtReferralDate);
			//----------------------------------------------------------------------
            // Create our Variables
            //----------------------------------------------------------------------
            Dictionary<string, int> dYMD = new Dictionary<string,int>();
            int iNowDate, iBirthDate, iYears, iMonths, iDays;
            string sDif = "";
            //----------------------------------------------------------------------
            // Store off current date/time and DOB into local variables
            //---------------------------------------------------------------------- 
            iNowDate = int.Parse(dtReferralDate.ToString("yyyyMMdd"));
            iBirthDate = int.Parse(dtBirthDate.ToString("yyyyMMdd"));
            //----------------------------------------------------------------------
            // Calculate Years
            //----------------------------------------------------------------------
            sDif = (iNowDate - iBirthDate).ToString();
            iYears = int.Parse(sDif.Substring(0, sDif.Length - 4));
            //----------------------------------------------------------------------
            // Store Years in Return Value
            //----------------------------------------------------------------------
            dYMD.Add("Years", iYears);
            //----------------------------------------------------------------------
            // Calculate Months
            //----------------------------------------------------------------------
            if (dtBirthDate.Month > dtReferralDate.Month)
                iMonths = 12 - dtBirthDate.Month + dtReferralDate.Month - 1;
            else
                iMonths = dtBirthDate.Month - dtReferralDate.Month;
            //----------------------------------------------------------------------
            // Store Months in Return Value
            //----------------------------------------------------------------------
            dYMD.Add("Months", iMonths);
            //----------------------------------------------------------------------
            // Calculate Remaining Days
            //----------------------------------------------------------------------
            if (dtBirthDate.Day > dtReferralDate.Day)
                //Logic: Figure out the days in month previous to the current month, or the admitted month.
                //       Subtract the birthday from the total days which will give us how many days the person has lived since their birthdate day the previous month.
                //       then take the referral date and simply add the number of days the person has lived this month.
                //If referral date is january, we need to go back to the following year's December to get the days in that month.
                if (dtReferralDate.Month == 1)
                    iDays = DateTime.DaysInMonth(dtReferralDate.Year - 1, 12) - dtBirthDate.Day + dtReferralDate.Day;       
                else
                    iDays = DateTime.DaysInMonth(dtReferralDate.Year, dtReferralDate.Month - 1) - dtBirthDate.Day + dtReferralDate.Day;       
            else
                iDays = dtReferralDate.Day - dtBirthDate.Day;             
            //----------------------------------------------------------------------
            // Store Days in Return Value
            //----------------------------------------------------------------------
            dYMD.Add("Days", iDays);
            return dYMD;
	}
