    class DateTimeInterval
    {
        public DateTime Start { get; }
        public DateTime End { get; }
    
        public TimeSpan Length { get { return End - Start; } }
        public DateTimeInterval(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException();
    
            Start = startDate;
            End = endDate;
        }
    
        public bool Intersect(DateTimeInterval other)
        {
            if((other.Start <= Start && other.End >= Start) || //left intersect
               (other.End >= End && other.Start <= End) || //right intersect
               (other.Start >= Start && other.End <= End)) //middle intersect
            {
                return true;
            }
    
            return false;
        }
        
        static public bool Intersect(DateTimeInterval dti1, DateTimeInterval dti2)
        {
            if ((dti1.Start <= dti2.Start && dti1.End >= dti2.Start) || //left intersect
               (dti1.End >= dti2.End && dti1.Start <= dti2.End) || //right intersect
               (dti1.Start >= dti2.Start && dti1.End <= dti2.End)) //middle intersect
            {
                return true;
            }
    
            return false;
        }
    }
