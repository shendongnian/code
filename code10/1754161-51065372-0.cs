    public class aaa
    {
        public string created_date { get; set; }
        //This code "runs" so to say. You can't put that in a class. 
        //DateTime journeyDate = DateTime.ParseExact(created_date, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture);
        //Can't do this either, because when will it be called? "runable" code needs to be in a method.
        //for(int i = 0; i < created_date.length; i++){
        //We can however only decalre journeyDate
        private DateTime journeyDate;
        //And then use either a method or constructor to set it:
        public void InitializeJourneyDate()
        {
            journeyDate = DateTime.ParseExact(created_date, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture);
        }
        public aaa()
        {
            journeyDate = DateTime.ParseExact(created_date, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture);
        }
        //Maybe the best method is to use a property getter. This will return a diffrent datetime automatically when you change your string
        private DateTime JourneyDateProp
        {
            get
            {
                return DateTime.ParseExact(created_date, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture);
            }
        }
    }
