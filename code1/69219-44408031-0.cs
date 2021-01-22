    public class DateDiffernce
    {
        private int m_nDays = -1;
        private int m_nWeek;
        private int m_nMonth = -1;
        private int m_nYear;
        public int Days
        {
            get
            {
                return m_nDays;
            }
        }
        public int Weeks
        {
            get
            {
                return m_nWeek;
            }
        }
        public int Months
        {
            get
            {
                return m_nMonth;
            }
        }
        public int Years
        {
            get
            {
                return m_nYear;
            }
        }
        public void GetDifferenceBetwwenTwoDate(DateTime objDateTimeFromDate, DateTime objDateTimeToDate)
        {
            if (objDateTimeFromDate.Date > objDateTimeToDate.Date)
            {
                DateTime objDateTimeTemp = objDateTimeFromDate;
                objDateTimeFromDate = objDateTimeToDate;
                objDateTimeToDate = objDateTimeTemp;
            }
            if (objDateTimeFromDate == objDateTimeToDate)
            {
                //textBoxDifferenceDays.Text = " Same dates";
                //textBoxAllDifference.Text = " Same dates";
                return;
            }
            // If From Date's Day is bigger than borrow days from previous month
            // & then subtract.
            if (objDateTimeFromDate.Day > objDateTimeToDate.Day)
            {
                int nMonthDays = DateTime.DaysInMonth(objDateTimeToDate.Year, objDateTimeToDate.Month - 1);
                m_nDays = objDateTimeToDate.Day + nMonthDays - objDateTimeFromDate.Day;
                objDateTimeToDate = objDateTimeToDate.AddMonths(-1);
            }
            
            // If From Date's Month is bigger than borrow 12 Month 
            // & then subtract.
            if (objDateTimeFromDate.Month > objDateTimeToDate.Month)
            {
                m_nMonth = objDateTimeToDate.Month + 12 - objDateTimeFromDate.Month;
                objDateTimeToDate = objDateTimeToDate.AddYears(-1);
            }
             
           //Below are best cases - simple subtraction
            if (m_nDays == -1)
            {
                m_nDays = objDateTimeToDate.Day - objDateTimeFromDate.Day;
            }
            if (m_nMonth == -1)
            {
                m_nMonth = objDateTimeToDate.Month - objDateTimeFromDate.Month;
            }
            m_nYear = objDateTimeToDate.Year - objDateTimeFromDate.Year;
            m_nWeek = m_nDays / 7;
            m_nDays = m_nDays % 7;    
        }
    }
