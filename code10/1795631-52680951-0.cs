        public Boolean SetDate(int Month, int Day, int Year)
        {
            if(StartDate==null)  // check if we already have a StartDate object
            {
                StartDate = new Date();  //if we don't create a new one
            }
            return StartDate.SetDate(Month, Day, Year);  //set the date and return result.
        }
