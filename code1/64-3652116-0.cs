       private int GetAge(int _year, int _month, int _day
        {
                DateTime yourBirthDate= new DateTime(_year, _month, _day);
        
                DateTime todaysDateTime = DateTime.Today;
                int noOfYears = todaysDateTime.Year - yourBirthDate.Year;
                if (DateTime.Now.Month < yourBirthDate.Month ||
     (DateTime.Now.Month == yourBirthDate.Month && DateTime.Now.Day < yourBirthDate.Day))
                {
                    noOfYears--;
                }
                return  noOfYears;
        }
