    public class MyService {
    
        // Private variables that will be initialized by constructor
    
        private readonly DateTimeOffset now;
    
        public MyService(MyFirstDependency dependency, DateTimeOffset now = DateTimeOffset.Now) {
             // Assign here your private variables
             this.now = now;
        }
    
    
        public void ValidateDateIsNotBefore3MonthsAgo(DateTimeOffset myDateToValidate) {
            if (!myDateToValidate.AddMonths(3).Date >= now.Date) {
                 throw new WhateverYouWantException("Date is before 3 months ago");
            }
        }
    
    }
