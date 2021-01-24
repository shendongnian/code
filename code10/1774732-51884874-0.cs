    public class DatesClass
    {
        [Column(CanBeNull = false)]
        private string FirstDate { get; set; } = string.Empty;
        [Column(CanBeNull = false)]
        private string SecondDate { get; set; } = string.Empty;
        [Column(CanBeNull = false)]
        private string ThirdDate { get; set; } = string.Empty;
        public List<DateTime> Dates
        {
            get
            {
                var dates = new List<DateTime>();
                DateTime temp;
                if (DateTime.TryParse(FirstDate, out temp)) dates.Add(temp);
                if (DateTime.TryParse(SecondDate, out temp)) dates.Add(temp);
                if (DateTime.TryParse(ThirdDate, out temp)) dates.Add(temp);
                return dates;
            }
        }
        public void AddDate(DateTime date)
        {
            if (Dates.Contains(date)) return;
            if (string.IsNullOrEmpty(FirstDate)) FirstDate = date.ToShortDateString();
            else if(string.IsNullOrEmpty(SecondDate)) SecondDate = date.ToShortDateString();
            else if(string.IsNullOrEmpty(ThirdDate)) ThirdDate = date.ToShortDateString();
            else throw new ManyDatesException();
        }
    }
